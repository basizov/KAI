using Renci.SshNet.Sftp;

namespace KAI.Storage.Core.Services.Base
{
	public interface IStorageService
	{
		void ChangeDirectory(string destinationPath);

		Task<IReadOnlyCollection<SftpFile>> GetContent(string destinationPath);

		Task<IReadOnlyCollection<SftpFile>> GetFiles(string destinationPath);

		Task<IReadOnlyCollection<SftpFile>> GetDirectories(string destinationPath);

		Task Upload(string destinationPath, MemoryStream content);
	}
}
