using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkId}/Training/{code}/[controller]")]
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
        /// <param name="talkId">Talk Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="LocationDTO"</returns>
        /// <response code="200">Returns a LocationDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        public async Task<ActionResult<LocationDTO>> Get(int talkId, string code)
        {
            var location = await _locationService.GetLocationAsync(talkId, code);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }
    }
}
