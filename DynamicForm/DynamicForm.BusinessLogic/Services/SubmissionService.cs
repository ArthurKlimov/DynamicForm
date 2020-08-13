using DynamicForm.BusinessLogic.Interfaces;
using DynamicForm.DataAccess;
using DynamicForm.DataAccess.Domain;
using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace DynamicForm.BusinessLogic.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly TestDbContext _db;
        
        public SubmissionService(TestDbContext db)
        {
            _db = db;
        }

        public async Task SaveSubmission(JsonElement submission)
        {
            var answers = submission.EnumerateObject();

            var newSubmission = new Submission();
            _db.Submissions.Add(newSubmission);

            var fields = _db.Fields;

            foreach (var answer in answers)
            {
                if (answer.Value.ValueKind == JsonValueKind.Null ||
                    answer.Value.ValueKind == JsonValueKind.Undefined ||
                    answer.Value.ValueKind == JsonValueKind.Object)
                    continue;

                var currentField = fields.FirstOrDefault(x => x.Name == answer.Name);
                if (currentField == null)
                {
                    currentField = new Field
                    {
                        Name = answer.Name
                    };

                    _db.Fields.Add(currentField);
                }

                if (answer.Value.ValueKind != JsonValueKind.Array)
                {
                    var newAnswer = new Answer
                    {
                        Value = answer.Value.ToString()
                    };

                    currentField.Answers.Add(newAnswer);
                    newSubmission.Answers.Add(newAnswer);
                    _db.Answers.Add(newAnswer);

                    continue;
                }

                foreach (var value in answer.Value.EnumerateArray())
                {
                    var newAnswer = new Answer
                    {
                        Value = value.ToString()
                    };

                    currentField.Answers.Add(newAnswer);
                    newSubmission.Answers.Add(newAnswer);
                    _db.Answers.Add(newAnswer);
                }
            }

            newSubmission.SubmissionDate = DateTime.UtcNow;

            await _db.SaveChangesAsync();
        }
    }
}
