using DAL.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                .IsRequired().
                HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired().
                HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                .IsRequired().
                HasMaxLength(256);

        }
    }

}
