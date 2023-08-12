using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    /// <summary>
    /// Talks Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly ITalkService _talkService;

        public TalksController(ITalkService talkService)
        {
            _talkService = talkService;
        }

        /// <summary>
        /// Gets the talks
        /// </summary>
        /// <returns>Returns a List of Talk</returns>
        /// <response code="200">Returns a List of Talk</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public ActionResult<IEnumerable<TalksDTO>> Get()
        {
            var talks = _talkService.GetTalksAsync();

            if (talks == null || !talks.Any())
            {
                return NoContent();
            }

            return Ok(talks);
        }
    }
}
