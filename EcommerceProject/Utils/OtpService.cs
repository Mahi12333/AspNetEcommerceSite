using System;
using System.Threading.Tasks;
using EcommerceProject.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

public class OtpService
{
    private readonly IEmailSender _emailSender;
    private readonly OtpManager _otpManager;

    public OtpService(IEmailSender emailSender, OtpManager otpManager)
    {
        _emailSender = emailSender;
        _otpManager = otpManager;
    }

    // Generate and send OTP to the user via email
    public async Task GenerateAndSendOtpAsync(string userEmail)
    {
        
        var otp = new Random().Next(1000, 9999).ToString(); // Generate a 4-digit OTP

        // Store OTP in the database using the OtpManager
        await _otpManager.StoreOtpAsync(userEmail, otp);

        // Send OTP via email
        var subject = "Your OTP Code";
        var htmlMessage = $"Your OTP code is: {otp}";
        await _emailSender.SendEmailAsync(userEmail, subject, htmlMessage);
    }

    // Verify OTP by checking it with the stored OTP in the database
    public async Task<bool> VerifyOtpAsync(string userEmail, string otp)
    {
        return await _otpManager.VerifyOtpAsync(userEmail, otp);
    }
}
