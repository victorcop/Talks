using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkReferenceId}/Training/{trainingReferenceId}/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        /// <summary>
        /// Gets a Location
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training Reference Id</param>
        /// <returns>Object of the type <see cref="LocationDTO"</returns>
        /// <response code="200">Returns a LocationDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        public async Task<ActionResult<LocationDTO>> Get(Guid talkReferenceId, Guid trainingReferenceId)
        {
            var location = await _locationService.GetLocationAsync(talkReferenceId, trainingReferenceId);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }
    }
}
