using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecisionSupport.DataAccess.Entities.Configuration
{
    public class VotingConfiguration : IEntityTypeConfiguration<Voting>
    {
        public void Configure(EntityTypeBuilder<Voting> builder)
        {
            builder.ToTable("Votings");

            builder.HasKey(x => x.Id);
        }
    }
}
