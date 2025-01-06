using Microsoft.AspNetCore.Mvc;

namespace olympo_webapi.Services
{
	public class GetFileServices : IGetFileServices
	{
		private readonly FileService _fileService;

		public GetFileServices()
		{
			_fileService = new FileService();
		}

		public async Task<string?> GetFileAsync(string fileName)
		{
			return await _fileService.GetFileAsync(fileName);
		}

		public class FileService
		{
			private readonly string _storageDirectory;

			public FileService()
			{
				_storageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Storage");

				if (!Directory.Exists(_storageDirectory))
				{
					Directory.CreateDirectory(_storageDirectory);
				}
			}

			public async Task<string?> GetFileAsync(string fileName)
			{
				string filePath = Path.Combine(_storageDirectory, fileName);
				if (File.Exists(filePath))
				{
					return filePath;
				}

				return null;
			}

			public async Task<bool> SaveFileAsync(string fileName, Stream fileStream)
			{
				try
				{
					string filePath = Path.Combine(_storageDirectory, fileName);
					using var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
					await fileStream.CopyToAsync(stream);
					return true;
				}
				catch
				{
					return false;
				}
			}

			public bool DeleteFile(string fileName)
			{
				try
				{
					string filePath = Path.Combine(_storageDirectory, fileName);
					if (File.Exists(filePath))
					{
						File.Delete(filePath);
						return true;
					}
					return false;
				}
				catch
				{
					return false;
				}
			}

			public string GetContentType(string fileName)
			{
				var extension = Path.GetExtension(fileName).ToLowerInvariant();
				return extension switch
				{
					".mp4" => "video/mp4",
					".mkv" => "video/x-matroska",
					".avi" => "video/x-msvideo",
					".mov" => "video/quicktime",
					".jpg" => "image/jpeg",
					".png" => "image/png",
					".gif" => "image/gif",
					".webp" => "image/webp",
					_ => "application/octet-stream",
				};
			}
		}
	}
}
