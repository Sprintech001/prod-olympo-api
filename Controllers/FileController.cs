using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Services;
using System.IO;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
	private readonly IGetFileServices _fileService;

	public FilesController(IGetFileServices fileService)
	{
		_fileService = fileService;
	}

	[HttpGet("images/{fileName}")]
	public async Task<IActionResult> GetImageFile(string fileName)
	{
		string path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "images", fileName);

		if (System.IO.File.Exists(path))
		{
			var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			var contentType = "image/jpeg"; 
			return File(stream, contentType, fileName);
		}

		return NotFound(new { message = "Image file not found." });
	}

	[HttpGet("videos/{fileName}")]
	public async Task<IActionResult> GetVideoFile(string fileName)
	{
		string path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "videos", fileName);

		if (System.IO.File.Exists(path))
		{
			var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			var contentType = "video/mp4"; 
			return File(stream, contentType, fileName, enableRangeProcessing: true);
		}

		return NotFound(new { message = "Video file not found." });
	}
}
