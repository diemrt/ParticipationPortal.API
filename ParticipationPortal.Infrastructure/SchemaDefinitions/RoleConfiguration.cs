using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParticipationPortal.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Infrastructure.SchemaDefinitions
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(Role.TableName, ParticipationPortalContext.DEFAULT_SCHEMA);
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar(32)")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(u => u.IconName)
                .HasColumnName("icon_name")
                .HasColumnType("nvarchar(64)")
                .HasMaxLength(64);
        }
    }
}
