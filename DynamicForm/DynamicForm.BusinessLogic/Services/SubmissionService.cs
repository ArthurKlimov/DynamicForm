using DynamicForm.BusinessLogic.Interfaces;
using DynamicForm.DataAccess;
using MongoDB.Bson;
using MongoDB.Bson.IO;
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

        public async Task<JsonDocument> GetSubmissions(JsonElement filter)
        {
            var documentFilter = BsonDocument.Parse(filter.ToString());

            var documentSubmissions = await _mongoRepository.GetSubmissions(documentFilter);

            var jsonWriterSettings = new JsonWriterSettings()
            {
                OutputMode = JsonOutputMode.Strict
            };

            return JsonDocument.Parse(documentSubmissions.ToJson(jsonWriterSettings));
        }
    }
}
