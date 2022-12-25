using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataAccess.Entities.Configuration
{
    public class AlternativeConfiguration : IEntityTypeConfiguration<Alternative>
    {
        public void Configure(EntityTypeBuilder<Alternative> builder)
        {
            builder.ToTable("Alternatives");

            builder.HasKey(x => x.Id);
        }
    }
}
