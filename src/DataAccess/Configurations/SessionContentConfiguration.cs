using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace DataAccess.Configurations;

public class SessionContentConfiguration : IEntityTypeConfiguration<SessionContent>
{
    public void Configure(EntityTypeBuilder<SessionContent> builder)
    {
        builder.HasOne(x => x.Session).WithMany(x => x.SessionContents)
            .HasForeignKey(x => x.SessionId);

        builder.HasOne(x => x.Subscriber).WithMany(x => x.SessionContents).
            HasForeignKey(x => x.SubscriberId);

        builder.HasOne(x => x.Question).WithMany(x => x.SessionContents).
            HasForeignKey(x => x.QuestionId);

        builder.HasOne(x => x.Answer).WithMany(x => x.SessionContents).
            HasForeignKey(x => x.AnswerId);

        builder.HasKey(x => new
        {

            x.SessionId,
            x.QuestionId,
            x.SubscriberId
        });

        builder.Property(x => x.Success).IsRequired();

        builder.Property(x => x.SessionId).IsRequired();
        builder.Property(x => x.SubscriberId).IsRequired();
        builder.Property(x => x.QuestionId).IsRequired();
    }  
}
