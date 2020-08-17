using DynamicForm.BusinessLogic.Interfaces;
using DynamicForm.DataAccess;
using MongoDB.Bson;
using System.Text.Json;
using System.Threading.Tasks;

namespace DynamicForm.BusinessLogic.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _mongoRepository;

        public SubmissionService(ISubmissionRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task SaveSubmission(JsonElement submission)
        {
            var documentSubmission = BsonDocument.Parse(submission.ToString());

            await _mongoRepository.CreateSubmission(documentSubmission);
        }
    }
}
