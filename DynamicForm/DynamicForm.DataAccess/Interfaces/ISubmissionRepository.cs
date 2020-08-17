using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamicForm.DataAccess
{
    public interface ISubmissionRepository
    {
        Task CreateSubmission(BsonDocument submission);
        Task<List<BsonDocument>> GetSubmissions(FilterDefinition<BsonDocument> filter);
    }
}
