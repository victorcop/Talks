using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkReferenceId}/Training/{trainingReferenceId}/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;
        public SpeakerController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        /// <summary>
        /// Gets a Speaker
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training Reference Id</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        /// <response code="200">Returns a SpeakerDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        public async Task<ActionResult<SpeakerDTO>> Get(Guid talkReferenceId, Guid trainingReferenceId)
        {
            var speaker = await _speakerService.GetSpeakerAsync(talkReferenceId, trainingReferenceId);

            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }
    }
}
