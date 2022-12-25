using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm.DataAccess.Entities.Configuration
{
    public class VotingResultConfiguration : IEntityTypeConfiguration<VotingResult>
    {
        public void Configure(EntityTypeBuilder<VotingResult> builder)
        {
            builder.ToTable("VotingResults");

            builder.HasKey(x => x.Id);
        }
    }
}
