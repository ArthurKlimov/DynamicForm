using System.Collections.Generic;

namespace DynamicForm.DataAccess.Domain
{
    public class Field : BaseEntity
    {
        public string Name { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
