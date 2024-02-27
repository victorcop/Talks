using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkReferenceId}/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;
        private readonly ILogger<TrainingController> _logger;

        public TrainingController(ITrainingService trainingService, ILogger<TrainingController> logger)
        {
            _trainingService = trainingService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the Trainings for a given Talk
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>IEnumerable of object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetTrainings(Guid talkReferenceId)
        {
            try
            {
                var trainings = await _trainingService.GetAllTrainingsAsync(talkReferenceId);

                if (trainings == null || !trainings.Any())
                {
                    _logger.LogInformation($"Training for talk {talkReferenceId} not found.");
                    return NoContent();
                }

                return Ok(trainings);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting Trainings for talk {talkReferenceId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Gets a Training
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training code</param>
        /// <returns>Object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{trainingReferenceId}")]
        public async Task<ActionResult<TalkDTO>> GetTraining(Guid talkReferenceId, Guid trainingReferenceId)
        {
            try
            {
                var training = await _trainingService.GetTrainingAsync(talkReferenceId, trainingReferenceId);

                if (training == null)
                {
                    _logger.LogInformation($"Training {trainingReferenceId} for talk {talkReferenceId} not found.");
                    return NotFound();
                }

                return Ok(training);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting Training {trainingReferenceId} for talk {talkReferenceId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }
    }
}
