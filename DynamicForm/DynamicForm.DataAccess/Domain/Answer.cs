namespace DynamicForm.DataAccess.Domain
{
    public class Answer : BaseEntity
    {
        public int SubmissionId { get; set; }
        public Submission Submission { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }
        public string Value { get; set; }
    }
}
