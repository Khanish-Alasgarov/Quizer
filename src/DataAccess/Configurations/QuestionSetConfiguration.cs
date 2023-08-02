using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DataAccess.Configurations;

public class QuestionSetConfiguration : IEntityTypeConfiguration<QuestionSet>
{
    public void Configure(EntityTypeBuilder<QuestionSet> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("QuestionSets");

        builder.Property(x => x.Subject).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
    }
}
