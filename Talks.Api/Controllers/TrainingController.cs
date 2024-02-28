using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkId}/[controller]")]
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
        /// <param name="talkId">Talk Id</param>
        /// <returns>IEnumerable of object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetTrainings(Guid talkId)
        {
            try
            {
                var trainings = await _trainingService.GetAllTrainingsAsync(talkId);

                if (trainings == null || !trainings.Any())
                {
                    _logger.LogInformation($"Training for talk {talkId} not found.");
                    return NoContent();
                }

                return Ok(trainings);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting Trainings for talk {talkId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Gets a Training
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="trainingId">Training code</param>
        /// <returns>Object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{trainingId}")]
        public async Task<ActionResult<TalkDTO>> GetTraining(Guid talkId, Guid trainingId)
        {
            try
            {
                var training = await _trainingService.GetTrainingAsync(talkId, trainingId);

                if (training == null)
                {
                    _logger.LogInformation($"Training {trainingId} for talk {talkId} not found.");
                    return NotFound();
                }

                return Ok(training);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting Training {trainingId} for talk {talkId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }
    }
}
