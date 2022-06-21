using KAI.Storage.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KAI.Storage.Data.Configurations
{
	internal class SoftDeletableConfiguration : IEntityTypeConfiguration<ISoftDeletable>
	{
		public void Configure(EntityTypeBuilder<ISoftDeletable> builder)
		{
			builder.HasIndex(dst => dst.IsDeleted);
		}
	}
}
