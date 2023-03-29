using Student.Achieve.Domain.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Users
{
    public class ChangePasswordDto
    {
        [Required]
        [MaxLength(UserConstants.PasswordLength)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [MaxLength(UserConstants.PasswordLength)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [MaxLength(UserConstants.PasswordLength)]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}