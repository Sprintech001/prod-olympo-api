using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olympo_webapi.Models
{

	public enum UserType
    {
        Administrador,
        Professor,
        Aluno
    }
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string? CPF { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public UserType Type { get; set; }
		public string? ImagePath { get; set; }
		public string? Password { get; set; }
		public List<Exercise>? Exercises { get; set; } = new List<Exercise>();

		[NotMapped]
		public IFormFile? Image { get; set; }
	}
}
