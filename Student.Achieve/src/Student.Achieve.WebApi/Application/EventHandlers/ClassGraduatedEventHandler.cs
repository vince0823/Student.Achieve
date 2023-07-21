using Fabricdot.Domain.Events;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using Student.Achieve.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.EventHandlers
{
    public class ClassGraduatedEventHandler : IDomainEventHandler<ClassGraduatedEvent>
    {
        private readonly IClassRepository _classRepository;
        private readonly AppDbContext _appDbContext;
        public ClassGraduatedEventHandler(IClassRepository classRepository, AppDbContext appDbContext)
        {
            _classRepository = classRepository;
            _appDbContext = appDbContext;
        }
        public async Task HandleAsync(ClassGraduatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var spec = new ClassFilterSpec(domainEvent.GradeId);
            var classes = await _classRepository.ListAsync(spec, cancellationToken);
            classes.ForEach(v => { v.Graduated(); });
            await _appDbContext.Classs.BulkUpdateAsync(classes);
        }
    }
}
