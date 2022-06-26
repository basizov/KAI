using KAI.Storage.Core.Services.Base;
using Renci.SshNet;
using Renci.SshNet.Async;
using Renci.SshNet.Sftp;

namespace KAI.Storage.Core.Services
{
	internal class StorageService : IStorageService, IDisposable
	{
		private readonly SftpClient _sftpClient;

		public StorageService()
		{
			_sftpClient = new SftpClient("", 22, "", "");
			_sftpClient.Connect();
		}

		public void ChangeDirectory(string destinationPath)
		{
			CheckDestinationPath(destinationPath);

			_sftpClient.ChangeDirectory(destinationPath);
		}

		public async Task<IReadOnlyCollection<SftpFile>> GetContent(string destinationPath)
		{
			CheckDestinationPath(destinationPath);

			var entries = await _sftpClient.ListDirectoryAsync(destinationPath);
			var content = entries.ToHashSet();

			return content;
		}

		public async Task<IReadOnlyCollection<SftpFile>> GetFiles(string destinationPath)
		{
			CheckDestinationPath(destinationPath);

			var entries = await _sftpClient.ListDirectoryAsync(destinationPath);
			var files = entries.Where(dst =>! dst.IsDirectory).ToHashSet();

			return files;
		}

		public async Task<IReadOnlyCollection<SftpFile>> GetDirectories(string destinationPath)
		{
			CheckDestinationPath(destinationPath);

			var entries = await _sftpClient.ListDirectoryAsync(destinationPath);
			var folders = entries.Where(dst => dst.IsDirectory).ToHashSet();

			return folders;
		}

		public async Task Upload(string destinationPath, MemoryStream content)
		{
			CheckDestinationPath(destinationPath);

			await _sftpClient.UploadAsync(content, destinationPath);
		}

		private void CheckDestinationPath(string destinationPath)
		{
			if (String.IsNullOrEmpty(destinationPath))
			{
				throw new ArgumentNullException($"{nameof(destinationPath)} couldn't be empty");
			}

			if (_sftpClient.Exists(destinationPath))
			{
				throw new ArgumentNullException($"{nameof(destinationPath)} doesn't exists");
			}
		}

		public void Dispose()
		{
			_sftpClient.Disconnect();
			_sftpClient.Dispose();
		}
	}
}
