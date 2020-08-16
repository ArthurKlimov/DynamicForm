﻿using System.Text.Json;
using System.Threading.Tasks;
using DynamicForm.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveFormSubmission ([FromBody] JsonElement submission)
        {
            await _submissionService.SaveSubmission(submission);
            return Ok();
        }
    }
}
