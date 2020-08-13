using System.Collections.Generic;

namespace DynamicForm.DataAccess.Domain
{
    public class Field : BaseEntity
    {
        public Field()
        {
            Answers = new List<Answer>();
        }
        public string Name { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
