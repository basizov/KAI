using KAI.Storage.Data.Entities.Abstract;

namespace KAI.Storage.Data.Repositories.Abstract
{
	internal interface IWithIdRepository<T> : IRepository<T>
		where T : class, IEntityWithId
	{
		Task<T> GetById(
			Guid id,
			CancellationToken cancellationToken = default);
	}
}
