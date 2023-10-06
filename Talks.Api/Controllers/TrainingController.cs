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

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        /// <summary>
        /// Gets the Trainings for a given Talk
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>IEnumerable of object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetTrainings(Guid talkReferenceId)
        {
            var trainings = await _trainingService.GetAllTrainingsAsync(talkReferenceId);

            if (trainings == null || !trainings.Any())
            {
                return NoContent();
            }

            return Ok(trainings);
        }

        /// <summary>
        /// Gets a Training
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="trainingReferenceId">Training code</param>
        /// <returns>Object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{trainingReferenceId}")]
        public async Task<ActionResult<TalkDTO>> GetTraining(Guid talkReferenceId, Guid trainingReferenceId)
        {
            var training = await _trainingService.GetTrainingAsync(talkReferenceId, trainingReferenceId);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }
    }
}
