using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();

            builder.Property(x => x.FullName).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
        }
    }
}
