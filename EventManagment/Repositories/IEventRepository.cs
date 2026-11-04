using EventManagment.Models;

namespace EventManagment.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> Get();
        Event? GetById(Guid id);
        bool Create(Event @event);
        bool Update(Event @event);
        bool DeleteById(Guid id);
    }
}