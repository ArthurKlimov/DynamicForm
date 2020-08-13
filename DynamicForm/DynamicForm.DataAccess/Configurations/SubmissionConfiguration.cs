using DynamicForm.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForm.DataAccess.Configurations
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Answers)
                    .WithOne(x => x.Submission)
                    .HasForeignKey(x => x.SubmissionId);
        }
    }
}
