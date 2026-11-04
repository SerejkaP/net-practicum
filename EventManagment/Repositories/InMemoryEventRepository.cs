using EventManagment.Models;

namespace EventManagment.Repositories
{
    public class InMemoryEventRepository : IEventRepository
    {
        private readonly Dictionary<Guid, Event> _events = new();
        private readonly Lock _lock = new();

        public IEnumerable<Event> Get()
        {
            lock (_lock)
            {
                return _events.Values.Select(Copy).ToArray();
            }
        }

        public Event? GetById(Guid id)
        {
            lock (_lock)
            {
                return _events.TryGetValue(id, out var @event) ? Copy(@event) : null;
            }
        }

        public bool Create(Event @event)
        {
            lock (_lock)
            {
                return _events.TryAdd(@event.Id, Copy(@event));
            }
        }

        public bool Update(Event @event)
        {
            lock (_lock)
            {
                if (!_events.ContainsKey(@event.Id))
                {
                    return false;
                }

                _events[@event.Id] = Copy(@event);
                return true;
            }
        }

        public bool DeleteById(Guid id)
        {
            lock (_lock)
            {
                return _events.Remove(id);
            }
        }

        private static Event Copy(Event @event)
        {
            return new Event
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                StartAt = @event.StartAt,
                EndAt = @event.EndAt
            };
        }
    }
}