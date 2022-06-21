using KAI.Storage.Data.Repositories.Abstract;

namespace KAI.Storage.Data.Repositories.Interfaces
{
	internal interface IFileRepository :
		ISoftRepository<Entities.File>,
		IWithIdRepository<Entities.File>
	{
	}
}
