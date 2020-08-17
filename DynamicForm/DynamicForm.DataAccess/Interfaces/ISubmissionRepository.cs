using MongoDB.Bson;
using System.Threading.Tasks;

namespace DynamicForm.DataAccess
{
    public interface ISubmissionRepository
    {
        Task CreateSubmission(BsonDocument submission);
    }
}
