using KAI.Storage.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace KAI.Storage.Data.Contexts
{
	internal class StorageDbContext : DbContext
	{
		public StorageDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Entities.File> Files => Set<Entities.File>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityWithIdConfiguration).Assembly);
		}
	}
}
