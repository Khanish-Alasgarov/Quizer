 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DataAccess.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Code).HasColumnType("varchar").HasMaxLength(7).IsRequired();
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.QuestionSetId).IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnType("datetime").IsRequired();

        builder.HasOne(x => x.QuestionSet).WithMany(x => x.Sessions).HasForeignKey(x => x.QuestionSetId);
    }
}
