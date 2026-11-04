using EventManagment.Dtos;
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

        [HttpGet()]
        public ActionResult<IEnumerable<EventDto>> Get()
        {
            return Ok(new List<EventDto>());
        }
    }
}
