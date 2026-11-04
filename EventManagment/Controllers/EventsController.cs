using EventManagment.Dtos;
using EventManagment.Models;
using EventManagment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventInfoDto>> Get()
        {
            var events = _eventService.Get().Select(ToInfoDto);
            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<EventInfoDto> GetById(Guid id)
        {
            var currentEvent = _eventService.GetById(id);
            if (currentEvent == null)
                return NotFound();

            return Ok(ToInfoDto(currentEvent));
        }

        [HttpPost]
        public ActionResult<EventInfoDto> Create([FromBody] EventDataDto @event)
        {
            if (@event.EndAt <= @event.StartAt)
            {
                ModelState.AddModelError(
                    nameof(EventDataDto.EndAt),
                    "Дата окончания должна быть позже даты начала"
                );
                return ValidationProblem(ModelState);
            }

            var newEvent = ToModel(@event);
            if (!_eventService.Create(newEvent))
                return Problem("Не удалось создать мероприятие");

            return CreatedAtAction(
                nameof(GetById),
                new { id = newEvent.Id },
                ToInfoDto(newEvent)
            );
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] EventDataDto @event)
        {
            if (@event.EndAt <= @event.StartAt)
            {
                ModelState.AddModelError(
                    nameof(EventDataDto.EndAt),
                    "Дата окончания должна быть позже даты начала"
                );
                return ValidationProblem(ModelState);
            }

            if (!_eventService.Update(ToModel(@event, id)))
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_eventService.DeleteById(id))
                return NotFound();

            return NoContent();
        }

        private static EventInfoDto ToInfoDto(Event @event)
        {
            return new EventInfoDto(
                @event.Id,
                @event.Title,
                @event.Description,
                @event.StartAt,
                @event.EndAt
            );
        }

        private static Event ToModel(EventDataDto dto, Guid id = default)
        {
            return new Event
            {
                Id = id,
                Title = dto.Title!,
                Description = dto.Description,
                StartAt = dto.StartAt!.Value,
                EndAt = dto.EndAt!.Value
            };
        }
    }
}
