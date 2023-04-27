using Fabricdot.Identity.Domain.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Commands.Grades;
using Student.Achieve.WebApi.Application.Commands.Tenants;
using System;

namespace Student.Achieve.WebApi.Application.Validators
{
    //public class CreateGradeCommandValidator : AbstractValidator<CreateGradeCommand>, IFluentValidation
    //{

    //    //private readonly IGradeRepository _gradeRepository;
    //    //private readonly IUserRepository<User> _userRepository;
    //    //public CreateGradeCommandValidator(IGradeRepository gradeRepository, IUserRepository<User> userRepository)
    //    //{
    //    //    _gradeRepository=gradeRepository;
    //    //    _userRepository=userRepository;

    //    //}
    //    public CreateGradeCommandValidator()
    //    {
    //        RuleFor(p => p.GradeName)
    //           .NotEmpty()
    //           .NotNull()
    //           .WithMessage("年级名称不为空");
    //        //RuleFor(p => p.GradeName)
    //        //  .MustAsync(async (name, ct) => await _gradeRepository.GetBySpecAsync(new GradeByNameSpec(name), ct) is null)
    //        //  .WithMessage("该年级名称已存在");
    //        RuleFor(p => p.EnrollmenYear)
    //          .NotEmpty()
    //          .NotNull()
    //          .LessThan(0)
    //          .WithMessage("入学年级不为空");
    //        //RuleFor(p => p.DutyUserID)
    //        //    .MustAsync(async (id, ct) => await _userRepository.GetByIdAsync((Guid)id, ct) is not null)
    //        //    .WithMessage("年级主任不存在");
    //    }
    //}
}
