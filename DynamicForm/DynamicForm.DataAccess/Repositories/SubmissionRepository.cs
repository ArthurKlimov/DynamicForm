using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace DynamicForm.DataAccess
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly IMongoCollection<BsonDocument> _submissions;

        public SubmissionRepository()
        {
            string connectionString = "mongodb+srv://arthur:157gQyDeshptBNwt@cluster0.ms36t.mongodb.net/TestDb?retryWrites=true&w=majority";
            
            var connection = new MongoUrlBuilder(connectionString);
            
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase(connection.DatabaseName);

            _submissions = database.GetCollection<BsonDocument>("Submissions");
        }

        public async Task CreateSubmission(BsonDocument submission)
        {
            await _submissions.InsertOneAsync(submission);
        }

        public async Task<List<BsonDocument>> GetSubmissions(FilterDefinition<BsonDocument> filter)
        {
            return await _submissions.Find(filter).ToListAsync();
        }
    }
}
