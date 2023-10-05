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
        /// <returns>IEnumerable of object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalkDTO>>> Get()
        {
            var talks = await _talkService.GetTalksAsync();

            if (talks == null || !talks.Any())
            {
                return NoContent();
            }

            return Ok(talks);
        }

        /// <summary>
        /// Gets a talk
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{talkReferenceId}", Name = "GetTalk")]
        public async Task<ActionResult<TalkDTO>> GetTalk(Guid talkReferenceId)
        {
            var talk = await _talkService.GetTalkAsync(talkReferenceId);

            if (talk == null)
            {
                return NotFound();
            }

            return Ok(talk);
        }

        /// <summary>
        /// Adds a talk
        /// </summary>
        /// <param name="TalkCreationDTO">Object of the type <see cref="TalkCreationDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="201">Created</response>
        /// <response code="204">Updated</response>
        [HttpPost]
        public async Task<IActionResult> CreateTalk(TalkCreationDTO talk)
        {
            var createdTalk = await _talkService.AddTalkAsync(talk);
            return CreatedAtRoute("GetTalk", new { TalkReferenceId = createdTalk.TalkReferenceId } , createdTalk);
        }

        /// <summary>
        /// Updates a talk
        /// </summary>
        /// <param name="TalkUpdateDTO">Object of the type <see cref="TalkUpdateDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="204">Updated</response>
        [HttpPut]
        public async Task<ActionResult> UpdateTalk(TalkUpdateDTO talk)
        {
            var existingTalk = await _talkService.GetTalkAsync(talk.TalkReferenceId);

            if (existingTalk == null) { return NotFound(); }

            await _talkService.UpdateTalkAsync(talk);

            return NoContent();
        }
    }
}
