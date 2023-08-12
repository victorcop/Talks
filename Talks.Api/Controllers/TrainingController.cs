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

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        /// <summary>
        /// Gets the Trainings for a given Talk
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <returns>IEnumerable of object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public ActionResult<IEnumerable<TrainingDTO>> Get(int talkId)
        {
            var trainings = _trainingService.GetAllTrainingsAsync(talkId);

            if (trainings == null || !trainings.Any())
            {
                return NoContent();
            }

            return Ok(trainings);
        }

        /// <summary>
        /// Gets a Training
        /// </summary>
        /// <param name="talkId">Talk Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="TrainingDTO"</returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{code}")]
        public ActionResult<TalkDTO> Get(int talkId, string code)
        {
            var training = _trainingService.GetTrainingAsync(talkId, code);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }
    }
}
