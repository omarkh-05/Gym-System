using BussinessLayer;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GymSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IPersonBLL _personBLL;
        readonly ISubscribersBLL _subscriberBLL;
        readonly ILogger<HomeController> _logger;
        public HomeController(IPersonBLL personBLL, ISubscribersBLL subscriberBLL, ILogger<HomeController> logger)
        {
            _personBLL = personBLL;
            _subscriberBLL = subscriberBLL;
            _logger = logger;
        }

        #region Subscriber
        [Authorize]
        [HttpGet("GetSubsProfile", Name = "Profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BussinessLayer.SubscriberDTO>> GetSubsProfile([FromServices] IAuthorizationService authorizationService)
        {
            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            var personIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(phoneNumber) ||
                !int.TryParse(personIdClaim, out int personId) || personId <= 0)
            {
                return Unauthorized("invalid token");
            }
            // Authorization check
            var authResult = await authorizationService.AuthorizeAsync(User, personId, "ClientOwnerOrAdmin");
            if (!authResult.Succeeded)
                return Forbid();

            var profile = await _subscriberBLL.GetSubscriberByPersonId(personId);

            if (profile == null)
                return NotFound("person not found");

            return Ok(profile);
        }
        #endregion

        #region Packages
        [HttpGet("GetGymSubPackages", Name = "SubPackages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGymPackages()
        {
            var packages = await SubsicriptionInfoBLL.GetAllGymSubPackages();

            if (packages == null)
                return StatusCode(500, "Error While Getting All Gym Sub Packages ");

            return Ok(packages);
        }

        [HttpGet("GetPackageByPackageName/{packageName}", Name = "GetPackageByPackageName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPackageByPackageName(string packageName)
        {
            if (string.IsNullOrWhiteSpace(packageName))
                return BadRequest("Invalid packageName");

            var packages = await SubsicriptionInfoBLL.GetPackFeesByPackageName(packageName);

            if (packages == null)
                return NotFound("No Packages Package Found");

            return Ok(packages);
        }

        [HttpGet("GetPackageById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPackageById(byte id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var package = SubsicriptionInfoBLL.Find(id);

            if (package == null)
                return NotFound();

            return Ok(package);
        }
        #endregion

        #region Subscribe-Process
        [Authorize]
        [HttpPost("AddSubscriber", Name = "AddSubscriber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddSubscriber([FromBody] AddSubscriberDTO subscribeRequest)
        {
            var phoneNumber = User.FindFirstValue(ClaimTypes.MobilePhone);
            var personIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(phoneNumber) ||
                !int.TryParse(personIdClaim, out int personId) ||
                personId <= 0)
            {
                return Unauthorized("invalid token");
            }

            if(subscribeRequest == null)
            {
                return BadRequest("Empty Subscriber");
            }

            int profile = await _subscriberBLL.AddSubscribersFE(subscribeRequest, personId);

            if (profile <= 0)
                return BadRequest("Error While Adding Subscriber");

            return Ok(profile);
        }
        #endregion
    }
}
