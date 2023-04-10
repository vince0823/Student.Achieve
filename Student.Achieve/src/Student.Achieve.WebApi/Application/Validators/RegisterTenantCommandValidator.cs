using FluentValidation;
using Student.Achieve.WebApi.Application.Commands.Tenants;
using Student.Achieve.WebApi.Application.Commands.Users;
using System;
using System.Text.RegularExpressions;

namespace Student.Achieve.WebApi.Application.Validators
{
    public class RegisterTenantCommandValidator : AbstractValidator<RegisterTenantCommand>, IFluentValidation
    {
        public RegisterTenantCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("租户名称不为空");
            RuleFor(p => p.UserName)
              .NotEmpty()
              .NotNull()
              .MaximumLength(256)
              .WithMessage("用户名不为空");
            RuleFor(p => p.Name)
              .NotEmpty()
              .NotNull()
              .WithMessage("租户名称不为空");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("请输入合适的密码");

            RuleFor(p => p.ConfirmPassword)
              .Equal(p=>p.Password)
                .WithMessage("两次密码输入不一致");
            RuleFor(p => p.GivenName)
             .NotEmpty()
             .NotNull()
             .MaximumLength(256)
             .WithMessage("姓名不为空");


            RuleFor(p => p.PhoneNumber)
                .Must(ValidPhoneNumber)
                .WithMessage("请输入合适的手机号");

        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }

        public bool ValidPhoneNumber(string phoneNumber)
        {
            var regex = new Regex(@"^(1)\d{10}$");

            return regex.IsMatch(phoneNumber);
        }
    }
}
