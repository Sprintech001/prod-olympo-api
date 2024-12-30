using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace olympo_webapi.Services
{
	public class FileUploadService : IFileUploadService
	{
		private readonly string _targetFilePath;

		public FileUploadService()
		{
			_targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
			Directory.CreateDirectory(_targetFilePath);
		}

		public async Task<string?> UploadFileAsync(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return null;
			}

			var fileName = Path.GetFileName(file.FileName);
			var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
			var filePath = string.Empty;

			var allowedExtensions = new[] { ".pdf", ".txt", ".json", ".jpg", ".png", ".jpeg", ".mp3", ".wav", ".mp4", ".mkv" };

			if (!allowedExtensions.Contains(fileExtension))
			{
				throw new InvalidOperationException("Esse tipo de arquivo não é permitido.");
			}

			string relativePath;
			if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
			{
				var imagesPath = Path.Combine(_targetFilePath, "images");
				Directory.CreateDirectory(imagesPath);
				filePath = Path.Combine(imagesPath, fileName);
				relativePath = Path.Combine("images", fileName);
			}
			else if (fileExtension == ".mp4" || fileExtension == ".mkv")
			{
				var videosPath = Path.Combine(_targetFilePath, "videos");
				Directory.CreateDirectory(videosPath);
				filePath = Path.Combine(videosPath, fileName);
				relativePath = Path.Combine("videos", fileName);
			}
			else
			{
				return null;
			}

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return relativePath.Replace("\\", "/");
		}
	}
}