using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkId}/Training/{trainingId}/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _speakerService;
        private readonly ILogger<SpeakerController> _logger;
        public SpeakerController(ISpeakerService speakerService, ILogger<SpeakerController> logger)
        {
            _speakerService = speakerService;
            _logger = logger;
        }

        /// <summary>
        /// Gets a Speaker
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="trainingId">Training Id</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        /// <response code="200">Returns a SpeakerDTO</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult<SpeakerDTO>> Get(Guid talkId, Guid trainingId)
        {
            try
            {
                var speaker = await _speakerService.GetSpeakerAsync(talkId, trainingId);

                if (speaker == null)
                {
                    _logger.LogInformation($"Speaker not found for Training {trainingId} and talk {talkId}");
                    return NotFound();
                }

                return Ok(speaker);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting Speaker for Training {trainingId} and talk {talkId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }
    }
}
