using System;
using System.Collections.Generic;

namespace DynamicForm.DataAccess.Domain
{
    public class Submission : BaseEntity
    {
        public Submission()
        {
            Answers = new List<Answer>();
        }
        public DateTime SubmissionDate { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
