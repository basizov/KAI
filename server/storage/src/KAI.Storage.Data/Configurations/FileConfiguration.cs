using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KAI.Storage.Data.Configurations
{
	internal class FileConfiguration : IEntityTypeConfiguration<Entities.File>
	{
		public void Configure(EntityTypeBuilder<Entities.File> builder)
		{
			builder.Property(dst => dst.AuthorId)
				.IsRequired();
			builder.Property(dst => dst.Name)
				.HasMaxLength(16)
				.IsRequired();
			builder.Property(dst => dst.Extension)
				.HasConversion<string>()
				.HasMaxLength(8)
				.IsRequired();
			builder.Property(dst => dst.Size)
				.IsRequired();
			builder.Property(dst => dst.Created)
				.IsRequired();

			builder.HasIndex(dst => dst.Name);
			builder.HasIndex(dst => dst.Extension);
		}
	}
}
