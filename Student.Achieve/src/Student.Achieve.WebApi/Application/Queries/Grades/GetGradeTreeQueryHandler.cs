using AutoMapper;
using Fabricdot.Infrastructure.Queries;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Grades
{
    public class GetGradeTreeQueryHandler : QueryHandler<GetGradeTreeQuery, ICollection<GradeTreeDto>>
    {

        private readonly IGradeRepository _gradeRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        public GetGradeTreeQueryHandler(IGradeRepository gradeRepository, IClassRepository classRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public override async Task<ICollection<GradeTreeDto>> ExecuteAsync(GetGradeTreeQuery query, CancellationToken cancellationToken)
        {

            var spec = new PagedGradeSpec();
            var grades = await _gradeRepository.ListAsync(spec, cancellationToken);
            var list = _mapper.Map<ICollection<GradeTreeDto>>(grades);
            //获取所有班级
            var gradeIds = grades.Select(g => g.Id).ToHashSet();
            var classSpec = new ClassFilterSpec(gradeIds);
            var classes = await _classRepository.ListAsync(classSpec, cancellationToken);
            var classesDict = classes.GroupBy(g => g.GradeId).ToDictionary(g => g.Key, g => g.ToList());
            list.ForEach(v =>
            {
                if (classesDict.TryGetValue(v.Id, out var selectClasses))
                {
                    v.Dtos = _mapper.Map<ICollection<ClassTreeDto>>(selectClasses);
                }
            });
            return list;
        }
    }
}
