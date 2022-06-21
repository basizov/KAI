using KAI.Storage.Data.Contexts;
using KAI.Storage.Data.Entities.Abstract;
using KAI.Storage.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KAI.Storage.Data.Repositories
{
	internal class SoftRepository<T> : Repository<T>, ISoftRepository<T>
		where T : class, ISoftDeletable
	{
		private readonly DbSet<T> _dbSet;
		private readonly StorageDbContext _context;

		public SoftRepository(StorageDbContext context) : base(context)
		{
			_dbSet = context.Set<T>();
			_context = context;
		}

		public override IQueryable<T> AsNoTracking()
		{
			return base.AsNoTracking().Where(dst => !dst.IsDeleted);
		}

		public override IQueryable<T> AsQueryable()
		{
			return base.AsQueryable().Where(dst => !dst.IsDeleted);
		}

		public override void Delete(T entity)
		{
			var entityEntry = _dbSet.Attach(entity);

			var modifiedEntity = entityEntry.Entity;
			modifiedEntity.IsDeleted = true;

			_context.Entry(modifiedEntity).State = EntityState.Modified;
		}
	}
}
