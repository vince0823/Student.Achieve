using Dapper;
using Fabricdot.Identity.Domain.Repositories;
using Fabricdot.Infrastructure.Data;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.MultiTenancy.Abstractions;
using Fabricdot.WebApi.Models;
using MediatR;
using Student.Achieve.Domain.Aggregates.UserAggregate;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.WebApi.Application.Queries.Tenants;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.Queries.Courses
{
    public class GetCoursePagedListQueryHandler : QueryHandler<GetCoursePagedListQuery, PagedResultDto<CoursePageDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly ICurrentTenant _currentTenant;
        private readonly IUserRepository<User> _userRepository;
        public GetCoursePagedListQueryHandler(ISqlConnectionFactory sqlConnectionFactory, ICurrentTenant currentTenant, IUserRepository<User> userRepository)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _currentTenant = currentTenant;
            _userRepository = userRepository;
        }


        public override async Task<PagedResultDto<CoursePageDto>> ExecuteAsync(GetCoursePagedListQuery query, CancellationToken cancellationToken)
        {
            const string cmd = @"select t.Id,t.CourseName,t.CreatorId,t.CreationTime from Courses t where 
                               t.IsDeleted=0 
                               and t.TenantId=@TenantId 
                               and (@CourseName is null or t.CourseName like '%'+@CourseName+'%')";
            var pagingCmd = $"{cmd} ORDER BY t.CreationTime DESC OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";
            var countCmd = $"SELECT COUNT(*) FROM ({cmd}) t";
            var param = new
            {
                Offset = query.GetOffset(),
                TenantId = _currentTenant.Id,
                query.Size,
                query.CourseName,
            };
            var dbConnection = _sqlConnectionFactory.GetOpenConnection();
            var queryCourses = await dbConnection.QueryAsync<CoursePageDto>(pagingCmd, param);
            var list = queryCourses.ToList();
            var creatorIds = list.Select(x => x.CreatorId).ToHashSet();
            var spec = new UserFilterSpec(creatorIds);
            var users = await _userRepository.ListAsync(spec, cancellationToken);
            list.ForEach(p =>
            {
                p.CreateUserName = users.FirstOrDefault(t => t.Id.ToString() == p.CreatorId)?.GivenName;
            });
            var total = await dbConnection.QuerySingleAsync<int>(countCmd, param);
            return new PagedResultDto<CoursePageDto>
            (
                 list,
                 total
            );
        }
    }
}
