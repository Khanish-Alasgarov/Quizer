using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DataAccess.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Questions"); 
        builder.Property(x => x.Text).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
        builder.Property(x => x.Point).HasColumnType("tinyint").IsRequired();
        builder.Property(x => x.QuestionSetId).IsRequired();
        builder.HasOne(x => x.QuestionSet).WithMany(x => x.Questions).HasForeignKey(x => x.QuestionSetId);
    }
}
