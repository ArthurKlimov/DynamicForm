using DynamicForm.DataAccess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DynamicForm.DataAccess.Configurations
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Answers)
                    .WithOne(x => x.Field)
                    .HasForeignKey(x => x.FieldId);
        }
    }
}
