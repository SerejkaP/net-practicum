using EventManagment.Models;

namespace EventManagment.Services
{
    public interface IEventService
    {
        IEnumerable<Event> Get();
        Event? GetById(Guid id);
        bool Create(Event @event);
        bool Update(Event @event);
        bool DeleteById(Guid id);
    }
}
