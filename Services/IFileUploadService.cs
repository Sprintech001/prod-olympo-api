using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace olympo_webapi.Services
{
	public interface IFileUploadService
	{
		Task<string?> UploadFileAsync(IFormFile file);
	}
}