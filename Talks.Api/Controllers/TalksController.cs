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
        private readonly ILogger<TalksController> _logger;

        public TalksController(ITalkService talkService, ILogger<TalksController> logger)
        {
            _talkService = talkService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the talks Async
        /// </summary>
        /// <returns>IEnumerable of object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a List of TalkDTO</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TalkDTO>>> GetAsync()
        {
            try
            {
                var talks = await _talkService.GetTalksAsync();

                if (talks == null || !talks.Any())
                {
                    _logger.LogInformation($"Talks not found.");
                    return NoContent();
                }

                return Ok(talks);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting talks", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Gets a talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="200">Returns a TalkDTO</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{talkReferenceId}", Name = "GetTalk")]
        public async Task<ActionResult<TalkDTO>> GetTalkAsync(Guid talkReferenceId)
        {
            try
            {
                var talk = await _talkService.GetTalkAsync(talkReferenceId);

                if (talk == null)
                {
                    _logger.LogInformation($"Talk {talkReferenceId} not found.");
                    return NotFound();
                }

                return Ok(talk);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while getting talk {talkReferenceId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Adds a talk Async
        /// </summary>
        /// <param name="TalkCreationDTO">Object of the type <see cref="TalkCreationDTO"/></param>
        /// <returns>Object of the type <see cref="TalkDTO"/></returns>
        /// <response code="201">Created</response>
        /// <response code="204">Updated</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        public async Task<IActionResult> CreateTalkAsync(TalkCreationDTO talk)
        {
            try
            {
                var createdTalk = await _talkService.AddTalkAsync(talk);
                return CreatedAtRoute("GetTalk", new { createdTalk.TalkReferenceId }, createdTalk);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while Creating talk.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Updates a talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="TalkUpdateDTO">Object of the type <see cref="TalkUpdateDTO"/></param>
        /// <response code="204">Updated</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>No Content</returns>
        [HttpPut("{talkReferenceId}")]
        public async Task<IActionResult> UpdateTalkAsync(Guid talkReferenceId, TalkUpdateDTO talk)
        {
            try
            {
                var existingTalk = await _talkService.GetTalkAsync(talkReferenceId);

                if (existingTalk == null)
                {
                    _logger.LogInformation($"Talk {talkReferenceId} not found.");
                    return NotFound();
                }

                await _talkService.UpdateTalkAsync(talkReferenceId, talk);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while updating talk {talkReferenceId}.", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Patch Talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <param name="patchDocument">JsonPatchDocument of the type <see cref="TalkToUpdateDTO"/></param>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>No Content</returns>
        [HttpPatch("{talkReferenceId}")]
        public async Task<IActionResult> PartialyUpadteTalkAsync(Guid talkReferenceId, JsonPatchDocument<TalkToUpdateDTO> patchDocument)
        {
            try
            {
                var talk = await _talkService.GetTalkAsync(talkReferenceId);

                if (talk == null)
                {
                    _logger.LogInformation($"Talk {talkReferenceId} not found.");
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
                    _logger.LogInformation($"Bad Request", patchDocument);
                    return BadRequest(ModelState);
                }

                if (!TryValidateModel(talkToPatch))
                {
                    _logger.LogInformation($"Bad Request", talkToPatch);
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
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while patching talk {talkReferenceId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }

        /// <summary>
        /// Delete Talk Async
        /// </summary>
        /// <param name="talkReferenceId">Talk Reference Id</param>
        /// <response code="404">Not Found</response>
        /// <response code="204">No Content</response>
        /// <response code="500">Internal Server Error</response>
        /// <returns>No Content</returns>
        [HttpDelete("{talkReferenceId}")]
        public async Task<IActionResult> DeleteTalkAsync(Guid talkReferenceId)
        {
            try
            {
                var talk = await _talkService.GetTalkAsync(talkReferenceId);

                if (talk == null)
                {
                    _logger.LogInformation($"Talk {talkReferenceId} not found.");
                    return NotFound();
                }

                await _talkService.DeleteTalkAsync(talkReferenceId);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Error while deleting talk {talkReferenceId}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to process your request");
            }
        }
    }
}
