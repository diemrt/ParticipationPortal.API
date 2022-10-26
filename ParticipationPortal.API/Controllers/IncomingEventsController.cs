using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipationPortal.Domain.RequestModels.v1.User;
using ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent;
using ParticipationPortal.Domain.ResponseModels.v1.User;
using ParticipationPortal.Domain.Services.v1;

namespace ParticipationPortal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/incoming-events")]
    public class IncomingEventsController : ControllerBase
    {
        private readonly IIncomingEventService _incomingEventService;

        public IncomingEventsController(IIncomingEventService incomingEventService)
        {
            this._incomingEventService = incomingEventService;
        }

        /// <summary>
        /// Create the incoming events of the next month
        /// </summary>
        [HttpPost()]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create()
        {
            await _incomingEventService.CreateNextAsync();
            return NoContent();
        }

        /// <summary>
        /// Get all incoming events
        /// </summary>
        [HttpGet()]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<GetAllIncomingEventsResponseModel>> GetAll()
        {
            GetAllIncomingEventsResponseModel result = await _incomingEventService.GetAllAsync();
            return Ok(result);
        }
    }
}
