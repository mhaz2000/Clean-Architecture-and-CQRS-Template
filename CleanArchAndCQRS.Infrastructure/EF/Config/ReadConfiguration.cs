using CleanArchAndCQRS.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchAndCQRS.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingLists");
            builder.HasKey(x => x.Id);

            builder
                .Property(c => c.Localization)
                .HasConversion(c => c.ToString(), c => LocalizationReadModel.Create(c));

            builder
                .HasMany(pl => pl.Items)
                .WithOne(pl => pl.PackingList);
        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");

        }
    }
}
