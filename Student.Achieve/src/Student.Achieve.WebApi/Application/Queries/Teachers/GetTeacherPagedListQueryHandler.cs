using AutoMapper;
using Dapper;
using Fabricdot.Identity.Domain.Specifications;
using Fabricdot.Infrastructure.Data;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.WebApi.Models;
using MediatR;
using Student.Achieve.Domain.Aggregates.RoleAggregate;
using Student.Achieve.Domain.Aggregates.TeacherAggregate;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Roles;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Teachers
{
    public class GetTeacherPagedListQueryHandler : QueryHandler<GetTeacherPagedListQuery, PagedResultDto<TeacherDetailsDto>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly ICurrentTenant _currentTenant;
        public GetTeacherPagedListQueryHandler(ITeacherRepository teacherRepository, IMapper mapper, ISqlConnectionFactory sqlConnectionFactory, ICurrentTenant currentTenant)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _sqlConnectionFactory = sqlConnectionFactory;
            _currentTenant = currentTenant;
        }

        public override async Task<PagedResultDto<TeacherDetailsDto>> ExecuteAsync(GetTeacherPagedListQuery query, CancellationToken cancellationToken)
        {
            #region dapper 写法
            //const string cmd = @"
            //         SELECT t.* FROM Teachers t
            //         WHERE  t.IsDeleted=0 
            //         AND    t.TenantId=@TenantId
            //         AND    (@TeacherName IS NULL OR t.TeacherName LIKE '%'+@TeacherName+'%')
            //         AND    (@TeacherPhoneNumber IS NULL OR t.PhoneNumber LIKE '%'+@TeacherPhoneNumber+'%')
            //       ";

            //var pagingCmd = $"{cmd} ORDER BY t.CreationTime DESC OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";
            //var countCmd = $"SELECT COUNT(*) FROM ({cmd}) t";
            //var param = new
            //{
            //    Offset = query.GetOffset(),
            //    TenantId = _currentTenant.Id,
            //    query.Size,
            //    query.TeacherName,
            //    query.TeacherPhoneNumber,

            //};
            //var dbConnection = _sqlConnectionFactory.GetOpenConnection();
            //var querys = await dbConnection.QueryAsync<Teacher>(pagingCmd, param);
            //var list = querys.ToList();
            //var total = await dbConnection.QuerySingleAsync<int>(countCmd, param);

            //return new PagedResultDto<TeacherDetailsDto>(_mapper.Map<ICollection<TeacherDetailsDto>>(list), total);
            #endregion

            var spec = new PagedTeacherSpec(query.GetOffset(), query.Size, query.TeacherName, query.TeacherPhoneNumber);
            var teachers=await _teacherRepository.ListAsync(spec,cancellationToken);
            var total= await _teacherRepository.CountAsync(spec, cancellationToken);
            return new PagedResultDto<TeacherDetailsDto>(_mapper.Map<ICollection<TeacherDetailsDto>>(teachers), total);

        }
    }
}
