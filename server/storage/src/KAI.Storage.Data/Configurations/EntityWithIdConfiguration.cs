using KAI.Storage.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KAI.Storage.Data.Configurations
{
	internal class EntityWithIdConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
		where TEntity : class, IEntityWithId
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(dst => dst.Id);
		}
	}
}
