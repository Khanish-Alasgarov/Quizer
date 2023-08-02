

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DataAccess.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Answers");
        builder.Property(x => x.Text).HasMaxLength(300).IsRequired();
        builder.Property(x => x.IsCorrect).IsRequired();
        builder.Property(x => x.QuestionId).IsRequired();
        builder.HasOne(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId);

    }
}
