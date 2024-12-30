using Microsoft.AspNetCore.Mvc;
using olympo_webapi.Services;

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
	public async Task<IActionResult> GetFile(string fileName)
	{
		// Caminho absoluto para a pasta onde os arquivos estão armazenados
		string path = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "images", fileName);

		// Verifique se o arquivo existe no caminho fornecido
		if (System.IO.File.Exists(path))
		{
			var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			var contentType = "application/octet-stream"; // Defina o content type de acordo com o arquivo
			return File(stream, contentType, fileName);
		}

		// Caso o arquivo não seja encontrado
		return NotFound(new { message = "File not found." });
	}
}
