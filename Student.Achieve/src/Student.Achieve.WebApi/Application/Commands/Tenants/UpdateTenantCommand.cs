using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Student.Achieve.WebApi.Application.Commands.Tenants
{
    public class UpdateTenantCommand : Command<Guid>
    {
        /// <summary>
        ///     租户Id
        /// </summary>
        [Required]
        public Guid TenantId { get; set; }

        /// <summary>
        ///     租户名称
        /// </summary>
        [Required(ErrorMessage = "{0} 必须填写")]
        public string Name { get; set; }
        /// <summary>
        ///     所有人Id
        /// </summary>
        [Required]
        public string OwnerId { get; set; }
    }


}
