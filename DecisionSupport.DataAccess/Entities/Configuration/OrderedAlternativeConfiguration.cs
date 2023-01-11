using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecisionSupport.DataAccess.Entities.Configuration
{
    public class OrderedAlternativeConfiguration : IEntityTypeConfiguration<OrderedAlternative>
    {
        public void Configure(EntityTypeBuilder<OrderedAlternative> builder)
        {
            builder.ToTable("OrderedAlternatives");

            builder.HasKey(x => x.Id);
        }
    }
}
