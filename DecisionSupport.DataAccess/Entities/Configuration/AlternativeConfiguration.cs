using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecisionSupport.DataAccess.Entities.Configuration
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
