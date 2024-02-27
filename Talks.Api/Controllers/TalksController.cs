using Microsoft.AspNetCore.JsonPatch;
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
        /// Gets the talks Async
        /// </summary>
        /// <returns>IEnumerable of object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalkDTO>>> GetAsync()
        {
            var talks = await _talkService.GetTalksAsync();

            if (talks == null || !talks.Any())
            {
                return NoContent();
            }

            return Ok(talks);
        }

        /// <summary>
        /// Gets a talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{talkReferenceId}", Name = "GetTalk")]
        public async Task<ActionResult<TalkDTO>> GetTalkAsync(Guid talkReferenceId)
        {
            var talk = await _talkService.GetTalkAsync(talkReferenceId);

            if (talk == null)
            {
                return NotFound();
            }

            return Ok(talk);
        }

        /// <summary>
        /// Adds a talk Async
        /// </summary>
        /// <param name="TalkCreationDTO">Object of the type <see cref="TalkCreationDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="201">Created</response>
        /// <response code="204">Updated</response>
        [HttpPost]
        public async Task<IActionResult> CreateTalkAsync(TalkCreationDTO talk)
        {
            var createdTalk = await _talkService.AddTalkAsync(talk);
            return CreatedAtRoute("GetTalk", new { TalkReferenceId = createdTalk.TalkReferenceId }, createdTalk);
        }

        /// <summary>
        /// Updates a talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="TalkUpdateDTO">Object of the type <see cref="TalkUpdateDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="204">Updated</response>
        [HttpPut("{talkReferenceId}")]
        public async Task<IActionResult> UpdateTalkAsync(Guid talkReferenceId, TalkUpdateDTO talk)
        {
            var existingTalk = await _talkService.GetTalkAsync(talkReferenceId);

            if (existingTalk == null) { return NotFound(); }

            await _talkService.UpdateTalkAsync(talkReferenceId, talk);

            return NoContent();
        }

        /// <summary>
        /// Patch Talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="patchDocument">JsonPatchDocument of the type <see cref="TalkToUpdateDTO"/></param>
        /// <returns></returns>
        [HttpPatch("{talkReferenceId}")]
        public async Task<IActionResult> PartialyUpadteTalkAsync(Guid talkReferenceId, JsonPatchDocument<TalkToUpdateDTO> patchDocument)
        {
            var talk = await _talkService.GetTalkAsync(talkReferenceId);

            if (talk == null)
            {
                return NotFound();
            }

            var talkToPatch = new TalkToUpdateDTO
            {
                Abstract = talk.Abstract,
                Title = talk.Title,
                Level = talk.Level
            };

            patchDocument.ApplyTo(talkToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(talkToPatch))
            {
                return BadRequest(ModelState);
            }

            var talkUpdateDTO = new TalkUpdateDTO
            {
                Abstract = talkToPatch.Abstract,
                Title = talkToPatch.Title,
                Level = talkToPatch.Level
            };

            await _talkService.UpdateTalkAsync(talkReferenceId, talkUpdateDTO);

            return NoContent();
        }

        /// <summary>
        /// Delete Talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns></returns>
        [HttpDelete("{talkReferenceId}")]
        public async Task<IActionResult> DeleteTalkAsync(Guid talkReferenceId)
        {
            var talk = await _talkService.GetTalkAsync(talkReferenceId);

            if (talk == null)
            {
                return NotFound();
            }

            await _talkService.DeleteTalkAsync(talkReferenceId);

            return NoContent();
        }
    }
}
