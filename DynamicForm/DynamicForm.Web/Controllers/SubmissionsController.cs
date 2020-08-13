using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DynamicForm.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        public async Task<IActionResult> SaveFormSubmission (JsonElement submission)
        {
            foreach (var element in submission.EnumerateObject())
            {
                var name = element.Name;
                var value = element.Value.ValueKind;
            };

            return Ok();
        }
    }
}
