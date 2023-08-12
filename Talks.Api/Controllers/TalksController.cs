using Microsoft.AspNetCore.Mvc;
using Talks.Domain;

namespace Talks.Api.Controllers
{
    /// <summary>
    /// Talks Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        public TalksController()
        {

        }

        /// <summary>
        /// Gets the talks
        /// </summary>
        /// <param name="code">Training Code</param>
        /// <returns>Returns a List of Talk</returns>
        /// <response code="200">Returns a List of Talk</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public ActionResult<IEnumerable<Talk>> Get()
        {
            var talks = new List<Talk>
            {
                new Talk { TalkId = 1, SpeakerId = 1, Title = "Teach Talk", Abstract =  "Best Web development frameworks on 2023", Level = 1},
                new Talk { TalkId = 1, SpeakerId = 1, Title = "Anime Talk", Abstract =  "Best Shonnen Jump Animes on 2023", Level = 1},
            };

            if (talks == null || !talks.Any())
            {
                return NoContent();
            }

            return Ok(talks);
        }
    }
}
