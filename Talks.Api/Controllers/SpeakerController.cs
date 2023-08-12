﻿using Microsoft.AspNetCore.Mvc;
using Talks.Service;
using Talks.Service.Models;

namespace Talks.Api.Controllers
{
    [Route("api/Talks/{talkId}/Training/{code}/[controller]")]
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
        /// <param name="talkId">Talk Id</param>
        /// <param name="code">Training code</param>
        /// <returns>Object of the type <see cref="SpeakerDTO"</returns>
        /// <response code="200">Returns a SpeakerDTO</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        public ActionResult<SpeakerDTO> Get(int talkId, string code)
        {
            var speaker = _speakerService.GetSpeakerAsync(talkId, code);

            if (speaker == null)
            {
                return NotFound();
            }

            return Ok(speaker);
        }
    }
}