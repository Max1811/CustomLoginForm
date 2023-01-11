using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecisionSupport.DataAccess.Entities.Configuration
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
