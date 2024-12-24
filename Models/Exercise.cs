using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olympo_webapi.Models
{
	public class Exercise
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? ImagePath { get; set; }
		public string? VideoPath { get; set; }
		public string? Link { get; set; }
		public int? Day { get; set; }
		public List<Session> sessions { get; set; } = new List<Session>();

		[NotMapped]
		public IFormFile? Image { get; set; }

		[NotMapped]
		public IFormFile? Video { get; set; }
	}
}
