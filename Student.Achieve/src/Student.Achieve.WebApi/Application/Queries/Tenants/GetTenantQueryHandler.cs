using Ardalis.GuardClauses;
using AutoMapper;
using Fabricdot.Infrastructure.Data;
using Fabricdot.Infrastructure.Queries;
using MediatR;
using Student.Achieve.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Student.Achieve.Domain.Aggregates.TenantAggregate;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    public class GetTenantQueryHandler : QueryHandler<GetTenantQuery, TenantDto>
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetTenantQueryHandler(
            ITenantRepository tenantRepository,
            IMapper mapper,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _sqlConnectionFactory = sqlConnectionFactory;
        }


        public async override Task<TenantDto> ExecuteAsync(GetTenantQuery query, CancellationToken cancellationToken)
        {
            var dbConnection = _sqlConnectionFactory.GetOpenConnection();
            var tenant = await dbConnection.QueryFirstOrDefaultAsync<Tenant>(
          $"SELECT * FROM [Tenants] WHERE Id  = '{query.TenantId}'", cancellationToken);
            Guard.Against.Null(tenant, nameof(tenant));
            //var tenant = await _tenantRepository.GetByIdAsync(query.TenantId, cancellationToken);
            return _mapper.Map<TenantDto>(tenant);
        }
    }
}
