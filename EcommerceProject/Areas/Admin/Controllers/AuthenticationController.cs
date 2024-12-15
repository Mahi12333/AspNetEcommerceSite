using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EcommerceProject.Repositories.Repository.IRepository;
using Azure.Identity;
using EcommerceProject.Utils;
using System.Security.Claims;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")] // Base route for the controller
    public class AuthenticationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly OtpService _otpService;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly TokenService _tokenService;

        public AuthenticationController(IUnitOfWork unitOfWork,
                                        SignInManager<ApplicationUserModel> signInManager,
                                        OtpService otpService,
                                        ILogger<AuthenticationController> logger,
                                        TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _otpService = otpService;
            _logger = logger;
            _tokenService = tokenService;
        }

        // GET: Admin/Authentication/Login
        [HttpGet("login")]
        public IActionResult Login()
        {
            // Check if there's an error message in TempData (from previous login attempt)
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }

            return View();
        }

        [HttpGet]
        public IActionResult LoginConfirmetionEmail(OtpConfirmationVM model)
        {
            // Check if there's an error message in TempData (from previous login attempt)
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }

            return View(model);
        }

        //api/admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginSubmit(LoginVM model)
        {
            //_logger.LogInformation("Received login request for email: {Email}", model.Email);

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid input.";
                return RedirectToAction("Login");
            }

            // Fetch user from database
            var user = await _unitOfWork.ApplicationUserRepository.GetUserByEmailAsync(model.Email);
            _logger.LogInformation("Received login request for email: {User}", user);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return RedirectToAction("Login");
            }
            // Genarate JWT and Refresh Tokens 
            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _unitOfWork.CompleteAsync();

            // Check if the password is correct
            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            _logger.LogInformation("Received login request for email: {passwordCheck}", passwordCheck);
            if (!passwordCheck.Succeeded)
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return RedirectToAction("Login");
            }

            // Log the user in
            await _signInManager.SignInAsync(user, isPersistent: true); //model.RememberMe

            // Generate and send OTP
            await _otpService.GenerateAndSendOtpAsync(user.Email);

            // Store email in TempData for OTP verification
            // TempData["UserEmail"] = user.Email;
            var otpConfirmationVM = new OtpConfirmationVM
            {
                userEmail = user.Email
            }; 


            _logger.LogInformation("Received : {Emailddd}", user.Email);
            // Redirect to OTP confirmation view
            return RedirectToAction("LoginConfirmetionEmail", otpConfirmationVM);
        }

        [HttpPost("otpverify")]
        public async Task<IActionResult> VerifyOtp(string otp, string userEmail)
        {
            // Retrieve the stored email
           // var userEmail = TempData["UserEmail"]?.ToString();

            if (string.IsNullOrEmpty(userEmail))
            {
                ModelState.AddModelError(string.Empty, "OTP expired or invalid.");
                return View("LoginConfirmetionEmail");
            }

            // Verify OTP
            var isOtpValid = await _otpService.VerifyOtpAsync(userEmail, otp);
            if (isOtpValid)
            {
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByEmailAsync(userEmail);
                _logger.LogInformation("OTP verified successfully for user {Email}.", userEmail);
                var username = user.UserName;
                // Generate JWT and Refresh Tokens
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _unitOfWork.CompleteAsync();

                // Store Tokens in Cookies
                HttpContext.Response.Cookies.Append("AccessToken", accessToken, new CookieOptions { HttpOnly = true, Secure = true });
                HttpContext.Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions { HttpOnly = true, Secure = true });
                // Pass the username if needed, or just redirect
                return RedirectToAction("Dashboard", "Home", new { username = username });
            }

            // If OTP is invalid
            TempData["ErrorMessage"] = "Invalid OTP. Please try again.";
            return View("LoginConfirmetionEmail", new OtpConfirmationVM { userEmail = userEmail });
        }


        // GET: Admin/Authentication/ResendOtp
        [HttpPost]
        public async Task<IActionResult> ResendOtp(string userEmail)
        {
            //var userEmail = TempData["UserEmail"]?.ToString();

            if (!string.IsNullOrEmpty(userEmail))
            {
                await _otpService.GenerateAndSendOtpAsync(userEmail);
                ViewBag.Message = "OTP has been resent to your email.";
                // Pass email back to the view
                var otpConfirmationVM = new OtpConfirmationVM
                {
                    userEmail = userEmail
                };
                return View("LoginConfirmetionEmail", otpConfirmationVM);
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid user email.";
                return RedirectToAction("Login");
            }
           
        }


        // GET: Admin/Authentication/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Extract email from User claims
            var email = User?.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
            {
                _logger.LogWarning("No email found in user claims during logout.");
                return RedirectToAction("Login");
            }

            // Fetch the user by email
            var user = await _unitOfWork.ApplicationUserRepository.GetUserByEmailAsync(email);
            if (user != null)
            {
                // Invalidate refresh token
                user.RefreshToken = null;
                await _unitOfWork.CompleteAsync();
            }

            _logger.LogInformation("User logged out.");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        // GET: Admin/Authentication/AccessDenied
        [HttpGet("admin/accessDenied")]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }


        [HttpPost]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = HttpContext.Request.Cookies["RefreshToken"];
            var accessToken = HttpContext.Request.Cookies["AccessToken"];

            if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(accessToken))
                return Unauthorized("Invalid tokens.");

            var principal = _tokenService.ValidateAccessToken(accessToken);
            if (principal == null)
            {
                var email = principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = await _unitOfWork.ApplicationUserRepository.GetUserByEmailAsync(email);

                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
                    return Unauthorized("Invalid or expired refresh token.");

                // Generate new tokens
                var newAccessToken = _tokenService.GenerateAccessToken(user);
                var newRefreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _unitOfWork.CompleteAsync();

                HttpContext.Response.Cookies.Append("AccessToken", newAccessToken, new CookieOptions { HttpOnly = true, Secure = true });
                HttpContext.Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions { HttpOnly = true, Secure = true });

                return Ok(new { AccessToken = newAccessToken });
            }

            return Unauthorized("Invalid tokens.");
        }


    }


}
