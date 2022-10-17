using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParticipationPortal.Domain.RequestModels.v1.User;
using ParticipationPortal.Domain.ResponseModels.v1.Role;
using ParticipationPortal.Domain.ResponseModels.v1.User;
using ParticipationPortal.Domain.Services.v1;

namespace ParticipationPortal.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/roles")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        /// <summary>
        /// Get all available roles
        /// </summary>
        [HttpGet()]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetAll()
        {
            GetAllRolesResponseModel result = await _roleService.GetAllAsync();
            return Ok(result);
        }
    }
}
