using Microsoft.AspNetCore.Mvc;

namespace olympo_webapi.Services
{
	public class GetFileServices : IGetFileServices
	{
		public async Task<string?> GetFileAsync(string fileName)
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", fileName);
			if (File.Exists(path))
			{
				var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
				var contentType = GetContentType(fileName);
				return path;
			}

			return null;
		}

		private string GetContentType(string fileName)
		{
			var extension = Path.GetExtension(fileName).ToLowerInvariant();
			return extension switch
			{
				".jpg" => "image/jpeg",
				".png" => "image/png",
				".gif" => "image/gif",
				".webp" => "image/webp",
				_ => "application/octet-stream",
			};
		}
	}
}
