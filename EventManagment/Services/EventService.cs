using EventManagment.Models;
using EventManagment.Repositories;

namespace EventManagment.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public bool Create(Event @event)
        {
            return _eventRepository.Create(@event);
        }

        public bool DeleteById(Guid id)
        {
            return _eventRepository.DeleteById(id);
        }

        public IEnumerable<Event> Get()
        {
            return _eventRepository.Get();
        }

        public Event? GetById(Guid id)
        {
            return _eventRepository.GetById(id);
        }

        public bool Update(Event @event)
        {
            return _eventRepository.Update(@event);
        }
    }
}