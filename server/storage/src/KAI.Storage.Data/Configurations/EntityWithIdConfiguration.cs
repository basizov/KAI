using KAI.Storage.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KAI.Storage.Data.Configurations
{
	internal class EntityWithIdConfiguration : IEntityTypeConfiguration<IEntityWithId>
	{
		public void Configure(EntityTypeBuilder<IEntityWithId> builder)
		{
			builder.HasKey(dst => dst.Id);
		}
	}
}
