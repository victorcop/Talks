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
        private readonly ILogger<SpeakerController> _logger;
        public SpeakerController(ISpeakerService speakerService, ILogger<SpeakerController> logger)
        {
            _speakerService = speakerService;
            _logger = logger;
        }

        /// <summary>
        /// Gets a Speaker
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training Reference Id</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        /// <response code="200">Returns a SpeakerDTO</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult<SpeakerDTO>> Get(Guid talkReferenceId, Guid trainingReferenceId)
        {
            try
            {
                var speaker = await _speakerService.GetSpeakerAsync(talkReferenceId, trainingReferenceId);

                if (speaker == null)
                {
                    _logger.LogInformation($"Speaker not found for Training {trainingReferenceId} and talk {talkReferenceId}");
                    return NotFound();
                }

                return Ok(speaker);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting Speaker for Training {trainingReferenceId} and talk {talkReferenceId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }
    }
}
