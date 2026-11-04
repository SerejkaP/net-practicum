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
            ValidateEventDates(@event.StartAt, @event.EndAt);
            @event.Id = Guid.NewGuid();
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
            ValidateEventDates(@event.StartAt, @event.EndAt);
            return _eventRepository.Update(@event);
        }

        private static void ValidateEventDates(DateTime startAt, DateTime endAt)
        {
            if (endAt <= startAt)
            {
                throw new ArgumentException(
                    "Дата окончания должна быть позже даты начала",
                    nameof(endAt)
                );
            }
        }
    }
}
