using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipationPortal.Domain.Errors.v1.Users;
using ParticipationPortal.Domain.RequestModels.v1.User;
using ParticipationPortal.Domain.ResponseModels.v1.User;
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

        /// <summary>
        /// Get information of a logged user
        /// </summary>
        [HttpGet()]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<IActionResult> Get()
        {
            var userId = User.FindFirst("user_id")?.Value;
            if (string.IsNullOrEmpty(userId)) throw new UserIdNotFoundException();

            GetUserByUserIdResponseModel result = await _userService.GetByUserIdAsync(userId);
            return Ok(result);
        }

        /// <summary>
        /// Create a record for a logged user
        /// </summary>
        /// <param name="model">Request model: AddUserRequestModel</param>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Add(AddUserRequestModel model)
        {
            var userId = User.FindFirst("user_id")?.Value;
            if (string.IsNullOrEmpty(userId)) throw new UserIdNotFoundException();

            await _userService.CreateAsync(userId, model);

            return NoContent();
        }
    }
}
