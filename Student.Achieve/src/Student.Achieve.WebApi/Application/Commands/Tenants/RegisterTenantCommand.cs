using Fabricdot.Identity.Domain.Constants;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    /// <summary>
    /// 注册租户
    /// </summary>
    public class RegisterTenantCommand:Command<Guid>
    {
        /// <summary>
        ///     名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
        [Required]
        [MaxLength(IdentityUserConstant.UserNameLength)]
        public string UserName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        ///     确认密码
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        [Required]
        [MaxLength(IdentityUserConstant.GivenNameLength)]
        public string GivenName { get; set; }


        public string Surname { get; set; } 
        /// <summary>
        ///     手机号
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

    }
}
