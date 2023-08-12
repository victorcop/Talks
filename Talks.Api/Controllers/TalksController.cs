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
        /// <returns>IEnumerable of object of the type <see cref="TalkDTO"</returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public ActionResult<IEnumerable<TalkDTO>> Get()
        {
            var talks = _talkService.GetTalksAsync();

            if (talks == null || !talks.Any())
            {
                return NoContent();
            }

            return Ok(talks);
        }

        /// <summary>
        /// Gets a talk
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"</returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{talkId}")]
        public ActionResult<TalkDTO> Get(int talkId)
        {
            var talk = _talkService.GetTalkAsync(talkId);

            if (talk == null)
            {
                return NotFound();
            }

            return Ok(talk);
        }
    }
}
