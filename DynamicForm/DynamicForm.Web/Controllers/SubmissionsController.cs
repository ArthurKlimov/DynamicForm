using System.Text.Json;
using System.Threading.Tasks;
using DynamicForm.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableCors]
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

        public async Task<IActionResult> GetSubmission (JsonElement filter)
        {
            var submissions = await _submissionService.GetSubmissions(filter);

            return Ok(submissions.RootElement);
        }
    }
}
