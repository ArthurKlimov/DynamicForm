using DynamicForm.BusinessLogic.Interfaces;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DynamicForm.BusinessLogic.Services
{
    public class SubmissionService : ISubmissionService
    {
        public Task SaveSubmission(JsonElement submission)
        {
            var answers = submission.EnumerateObject();
            //Достать все поля из базы
            //Создать новый объект submission

            foreach (var answer in answers)
            {
                if (answer.Value.ValueKind == JsonValueKind.Null ||
                    answer.Value.ValueKind == JsonValueKind.Undefined ||
                    answer.Value.ValueKind == JsonValueKind.Object)
                    continue;

                if (answer.Value.ValueKind != JsonValueKind.Array)
                {
                    //если answer.name нет в списке полей базы, то добавить поле
                    //Создать новый Answer и привязать его к полю 
                    //А потом добавить его к submission
                }

                foreach (var item in answer.Value.EnumerateArray())
                {
                    //если answer.name нет в списке полей базы, то добавить поле
                    //Создать новый Answer и привязать его к полю 
                    //А потом добавить его к submission
                }
            }
        }
    }
}
