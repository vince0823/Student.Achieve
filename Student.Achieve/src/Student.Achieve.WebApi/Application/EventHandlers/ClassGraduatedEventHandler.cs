using Fabricdot.Domain.Events;
using Student.Achieve.Domain.Events;
using Student.Achieve.Domain.Repositories;
using Student.Achieve.Domain.Specifications;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Achieve.WebApi.Application.EventHandlers
{
    public class ClassGraduatedEventHandler : IDomainEventHandler<ClassGraduatedEvent>
    {
        private readonly IClassRepository _classRepository;
        public ClassGraduatedEventHandler(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }
        public async Task HandleAsync(ClassGraduatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var spec = new ClassFilterSpec(domainEvent.GradeId);
            var classes = await _classRepository.ListAsync(spec, cancellationToken);
            foreach (var c in classes)
            {
                c.Graduated();
                await _classRepository.UpdateAsync(c, cancellationToken);
            } 
        }
    }
}
