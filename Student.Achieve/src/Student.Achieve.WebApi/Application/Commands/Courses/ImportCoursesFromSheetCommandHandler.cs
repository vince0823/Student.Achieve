using Fabricdot.Core.UniqueIdentifier;
using Fabricdot.Infrastructure.Commands;
using Fabricdot.MultiTenancy.Abstractions;
using Org.BouncyCastle.Asn1.Ocsp;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Shared.Exceptions;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Services.ImportSheet;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Commands.Courses
{
    public class ImportCoursesFromSheetCommandHandler : CommandHandler<ImportCoursesFromSheetCommand, ImportSheetResultDto>
    {
        private readonly IImportService _importService;
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICourseRepository _courseRepository;


        public ImportCoursesFromSheetCommandHandler(IImportService importService, IGuidGenerator guidGenerator, ICourseRepository courseRepository)
        {
            _importService = importService;
            _guidGenerator = guidGenerator;
            _courseRepository = courseRepository;

        }

        public override async Task<ImportSheetResultDto> ExecuteAsync(ImportCoursesFromSheetCommand command, CancellationToken cancellationToken)
        {
            var rows = command.Rows;
            var errorInfos = await _importService.TryReadValuesAsync<ImporCourseDto>(rows, async (dto, _, __) =>
            {

                var filter = new CourseFilter(dto.CourseName);
                var oldCourse = await _courseRepository.GetBySpecAsync(filter, cancellationToken);
                if (oldCourse != null)
                {
                    throw new CustomException($"系统内已存在{dto.CourseName}课程");
                }
                var course = new Domain.Aggregates.CourseAggregate.Course(_guidGenerator.Create(), command.TenantId, dto.CourseName);
                await _courseRepository.AddAsync(course, cancellationToken);
            }, cancellationToken: cancellationToken);

            return new ImportSheetResultDto
            {
                Total = rows.Count,
                Errors = errorInfos
            };
        }
    }
}
