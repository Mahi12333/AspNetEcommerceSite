using EcommerceProject.Areas.Admin.Models;
using EcommerceProject.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EcommerceProject.Repositories.Repository.IRepository;
using Azure.Identity;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("api/admin")]
    public class AuthenticationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly OtpService _otpService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IUnitOfWork unitOfWork,
                                        SignInManager<ApplicationUserModel> signInManager,
                                        OtpService otpService,
                                        ILogger<AuthenticationController> logger)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _otpService = otpService;
            _logger = logger;
        }

        // GET: Admin/Authentication/Login
        [HttpGet]
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
            _logger.LogInformation("Received login request for email: {Email}", model.Email);

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
            _logger.LogInformation("User logged out.");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        // GET: Admin/Authentication/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

    }


}
