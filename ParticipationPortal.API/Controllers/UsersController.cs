using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipationPortal.Domain.RequestModels.v1;
using ParticipationPortal.Domain.Services.v1;

namespace ParticipationPortal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public IActionResult Get()
        {
            var userId = User.FindFirst("user_id").Value;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a record for a logged user
        /// </summary>
        /// <param name="model">Request model: AddUserRequestModel</param>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Add(AddUserRequestModel model)
        {
            var userId = User.FindFirst("user_id").Value;
            await _userService.CreateAsync(userId, model);

            return NoContent();
        }
    }
}
