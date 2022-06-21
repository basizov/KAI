using KAI.Storage.Data.Contexts;
using KAI.Storage.Data.Entities.Abstract;
using KAI.Storage.Data.Exceptions;
using KAI.Storage.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace KAI.Storage.Data.Repositories
{
	internal class WithIdRepository<T> : Repository<T>, IWithIdRepository<T>
		where T : class, IEntityWithId
	{
		private readonly DbSet<T> _dbSet;

		public WithIdRepository(StorageDbContext context) : base(context)
		{
			_dbSet = context.Set<T>();
		}

		public async Task<T> GetById(
			Guid id,
			CancellationToken cancellationToken = default)
		{
			var entity = await _dbSet.SingleOrDefaultAsync(dst => dst.Id == id, cancellationToken);

			if (entity is null)
			{
				throw new EntityNotFoundException($"Entity with id {id} not found");
			}

			return entity;
		}

		public override Task<T> Create(T entity)
		{
			entity.Id = Guid.NewGuid();
			return base.Create(entity);
		}
	}
}
