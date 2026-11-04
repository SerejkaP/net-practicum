using EventManagment.Models;

namespace EventManagment.Services
{
    public interface IEventService
    {
        public IEnumerable<Event> Get();
        public Event? GetById(Guid id);
        public bool Create(Event @event);
        public bool Update(Event @event);
        public bool DeleteById(Guid id);
    }
}
