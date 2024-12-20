using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class Exercise
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		
		public int? Type { get; set; }
		public List<Session> sessions { get; set; } = new List<Session>();

	}
}
