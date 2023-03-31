using Ardalis.GuardClauses;
using Dapper;
using Fabricdot.Infrastructure.Data;
using Fabricdot.Infrastructure.Queries;
using Fabricdot.WebApi.Models;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Student.Achieve.WebApi.Application.Queries.Tenants
{
    public class GetTenantPagedListQueryHandler : QueryHandler<GetTenantPagedListQuery, PagedResultDto<TenantDetailsDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetTenantPagedListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async override Task<PagedResultDto<TenantDetailsDto>> ExecuteAsync(GetTenantPagedListQuery request, CancellationToken cancellationToken)
        {
            const string cmd = @"
                SELECT t.*,u.Id UserId,u.UserName,u.GivenName,u.Surname,u.PhoneNumber
                FROM Tenants t
                    LEFT JOIN IdentityUsers u ON u.Id = t.OwnerId
                WHERE t.IsDeleted = 0
                    AND ( @IsEnabled IS NULL OR t.IsEnabled = @IsEnabled )
                    AND ( @Name IS NULL OR t.Name LIKE '%'+@Name+'%')
                    AND ( @OwnerPhoneNumber IS NULL OR u.PhoneNumber LIKE '%'+@OwnerPhoneNumber+'%')";

             var pagingCmd = $"{cmd} ORDER BY t.CreationTime DESC OFFSET @Offset ROWS FETCH NEXT @Size ROWS ONLY";
            #region sql2012版本以下写法
            //string[] str = cmd.Split("FROM", cmd.Length);
            //string selectSQL = "SELECT *";
            //string fromSQL = " from ";
            //string tableSQL = str[1];
            //string modelSQL = " (select ROW_NUMBER()Over(order by  t.CreationTime desc ) as rowId,t.*,u.Id UserId,u.UserName,u.GivenName,u.Surname,u.PhoneNumber from " + tableSQL + " ) as z ";
            //string whereSQL = "where rowId between  (@Index - 1) * (@Size + 1)   and  (@Index * @Size)";
            //string exeSql = selectSQL + fromSQL + modelSQL + whereSQL;
            #endregion
            var countCmd = $"SELECT COUNT(*) FROM ({cmd}) t";

            var param = new
            {
                Offset = request.GetOffset(),
                request.Size,
                request.Name,
                request.OwnerPhoneNumber,
                request.IsEnabled
            };

            var dbConnection = _sqlConnectionFactory.GetOpenConnection();
            var query = await dbConnection.QueryAsync<TenantDetailsDto, TenantOwnerDto, TenantDetailsDto>(
                pagingCmd,
                (tenant, owner) =>
                {
                    tenant.Owner = owner;
                    return tenant;
                },
                param: param,
                splitOn: "UserId");
            var list = query.ToList();
            var total = await dbConnection.QuerySingleAsync<int>(countCmd, param);



            return new PagedResultDto<TenantDetailsDto>
            (
                 list,
                 total
            );
        }

    }

}
