using EcommerceProject.Repositories.Repository.IRepository;
using EcommerceProject.Areas.Admin.Models;
using System;
using System.Threading.Tasks;

namespace EcommerceProject.Services
{
    public class OtpManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public OtpManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Store OTP in the database
        public async Task StoreOtpAsync(string userEmail, string otp)
        {
            // Check if OTP for this email already exists
            var existingOtp = await _unitOfWork.OtpRepository.GetFirstOrDefaultAsync(o => o.UserId == userEmail && !o.IsUsed);

            if (existingOtp != null)
            {
                // Update existing OTP
                existingOtp.Otp = otp;
                existingOtp.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.OtpRepository.Update(existingOtp);
            }
            else
            {
                // Create new OTP record
                var otpEntry = new OtpModel
                {
                    Otp = otp,
                    UserId = userEmail,
                    IsUsed = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                await _unitOfWork.OtpRepository.AddAsync(otpEntry);
            }

            // Save changes
            await _unitOfWork.CompleteAsync();
        }

        // Verify OTP
        public async Task<bool> VerifyOtpAsync(string userEmail, string otp)
        {
            // Find the OTP entry
            var otpEntry = await _unitOfWork.OtpRepository.GetFirstOrDefaultAsync(o => o.UserId == userEmail && o.Otp == otp && !o.IsUsed);

            if (otpEntry != null)
            {
                // OTP is valid, mark it as used
                otpEntry.IsUsed = true;
                otpEntry.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.OtpRepository.Update(otpEntry);

                // Save changes
                await _unitOfWork.CompleteAsync();

                return true;
            }

            // OTP is either invalid or already used
            return false;
        }
    }
}
