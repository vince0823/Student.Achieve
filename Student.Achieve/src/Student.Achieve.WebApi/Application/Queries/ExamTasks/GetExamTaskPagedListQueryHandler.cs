using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.ExamTasks
{
    public class GetExamTaskPagedListQueryHandler : QueryHandler<GetExamTaskPagedListQuery, PagedResultDto<ExamTaskPageDto>>
    {
        private readonly IExamTaskRepository _examTaskRepository;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IClassRepository _classRepository;

        public GetExamTaskPagedListQueryHandler(IExamTaskRepository examTaskRepository, IMapper mapper, ICourseRepository courseRepository, IClassRepository classRepository)
        {
            _examTaskRepository = examTaskRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
            _classRepository = classRepository;
        }

        public override async Task<PagedResultDto<ExamTaskPageDto>> ExecuteAsync(GetExamTaskPagedListQuery query, CancellationToken cancellationToken)
        {
            var spec = new PagedExamTaskSpec(query.GetOffset(), query.Size, query.TaskName, query.AcademicYear, query.Semester);
            var tasks = await _examTaskRepository.ListAsync(spec, cancellationToken);
            var total = await _examTaskRepository.CountAsync(spec, cancellationToken);
            var classes = await _classRepository.ListAsync(cancellationToken);
            var courses = await _courseRepository.ListAsync(cancellationToken);
            var classIds = tasks.SelectMany(t => t.examTask_Classes.Select(c => c.ClassId)).ToHashSet();
            var courseIds = tasks.SelectMany(t => t.examTask_Courses.Select(c => c.CourseId)).ToHashSet();
            var dtos = tasks.Select(task => new ExamTaskPageDto
            {
                Id = task.Id,
                TaskName = task.TaskName,
                StartTime = task.StartTime,
                EndTime = task.EndTime,
                AcademicYear = task.AcademicYear,
                Semester = task.Semester,
                CourseNames = string.Join(",", courses.Where(c => courseIds.Contains(c.Id)).Select(c => c.CourseName)),
                ClassNames = string.Join(",", classes.Where(c => classIds.Contains(c.Id)).Select(c => c.ClassName))
            }).ToList();
            return new PagedResultDto<ExamTaskPageDto>(dtos, total);
        }
    }
}
