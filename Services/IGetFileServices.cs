namespace olympo_webapi.Services
{
	public interface IGetFileServices
	{
		Task<string?> GetFileAsync(string fileName);
	}
}
