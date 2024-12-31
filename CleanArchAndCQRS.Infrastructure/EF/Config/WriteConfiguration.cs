using CleanArchAndCQRS.Domain.Entities;
using CleanArchAndCQRS.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchAndCQRS.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
    {
        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.ToTable("PackingLists");
            builder.HasKey(x => x.Id);

            var localizationConverter = new ValueConverter<Localization, string>(l => l.ToString(), l => Localization.Create(l));
            var packingListNameConverter = new ValueConverter<PackingListName, string>(pln => pln.Value, pln => new PackingListName(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new PackingListId(id));

            builder
                .Property(typeof(Localization), "_localization")
                .HasConversion(localizationConverter)
                .HasColumnName("Localization");

            builder
                .Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConverter)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingItem), "_items");

        }

        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            builder.Property<Guid>("Id");

            builder.Property(c => c.Name);
            builder.Property(c => c.Quantity);
            builder.Property(c => c.IsPacked);

            builder.ToTable("PackingItems");
        }
    }
}
