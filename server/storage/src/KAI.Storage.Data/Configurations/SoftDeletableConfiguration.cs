using KAI.Storage.Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KAI.Storage.Data.Configurations
{
	internal class SoftDeletableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
		where TEntity : class, ISoftDeletable
	{
		public virtual void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasIndex(dst => dst.IsDeleted);
		}
	}
}
