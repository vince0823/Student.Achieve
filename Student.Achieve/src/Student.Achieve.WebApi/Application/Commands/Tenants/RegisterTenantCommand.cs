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
      
        public string Name { get; set; }

        /// <summary>
        ///     用户名
        /// </summary>
     
        public string UserName { get; set; }

        /// <summary>
        ///     密码
        /// </summary>
       
        public string Password { get; set; }

        /// <summary>
        ///     确认密码
        /// </summary>
      
        public string ConfirmPassword { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
      
        public string GivenName { get; set; }


        public string Surname { get; set; } 
        /// <summary>
        ///     手机号
        /// </summary>
     
        public string PhoneNumber { get; set; }

    }
}
