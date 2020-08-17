using MongoDB.Bson;
using System.Text.Json;
using System.Threading.Tasks;

namespace DynamicForm.BusinessLogic.Interfaces
{
    public interface ISubmissionService
    {
        Task SaveSubmission(JsonElement submission);
    }
}
