using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Configuration
{
    public interface IHangfireJob
    {
        public Task<bool> RunJob();
    }
}
