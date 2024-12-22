using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olympo_webapi.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string? CPF { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }

		[NotMapped]
		public IFormFile? Photo { get; set; }

		public string? PhotoPath { get; set; }
		public string? Password { get; set; }
		public List<Exercise> Exercise { get; set; } = new List<Exercise>();
	}
}
