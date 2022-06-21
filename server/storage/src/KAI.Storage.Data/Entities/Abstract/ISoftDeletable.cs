namespace KAI.Storage.Data.Entities.Abstract
{
	internal interface ISoftDeletable
	{
		bool IsDeleted { get; set; }
	}
}
