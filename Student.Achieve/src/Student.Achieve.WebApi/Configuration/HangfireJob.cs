using Fabricdot.MultiTenancy;
using Fabricdot.MultiTenancy.Abstractions;
using Microsoft.AspNetCore.Http;
using Serilog;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.Infrastructure.International.Cookies;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Student.Achieve.WebApi.Configuration
{
    public class HangfireJob : IHangfireJob
    {
        private ITeacherRepository _teacherRepository;
        private ITenantRepository _tenantRepository;
        private ICurrentTenant _currentTenant;
        public HangfireJob(ITeacherRepository teacherRepository, ITenantRepository tenantRepository, ICurrentTenant currentTenant)
        {
            _teacherRepository = teacherRepository;
            _tenantRepository = tenantRepository;
            _currentTenant = currentTenant;


        }
        public async Task<bool> RunJob()
        {
            Log.Information($"start time: {DateTime.Now}");
            // 模拟任务执行

            var tenants = await _tenantRepository.ListAsync();
            foreach (var tenant in tenants)
            {
                _currentTenant.Change(tenant.Id, tenant.Name);
                var spec = new TeacherSpec(tenant.Id);
                var list = await _teacherRepository.ListAsync(spec);
                var teacherNames = list.Select(v => v.TeacherName).ToList();
                var infor = string.Join(",", teacherNames);
                Log.Information($"TacherName:{infor}");
            }

            Log.Information("Hello world from Hangfire in Recurring mode!");

            Log.Information($"stop time: {DateTime.Now}");
            return true;
        }
    }
}
