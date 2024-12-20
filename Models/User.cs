using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace olympo_webapi.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public string CPF { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		[NotMapped]
		public IFormFile Photo { get; set; }

		public string PhotoPath { get; set; }
		public string Password { get; set; }
		public List<Exercise> Exercise { get; set; } = new List<Exercise>();

		public User() { }


		public User(string cpf, string name, string email, string password, string photoPath)
		{
			CPF = cpf;
			Name = name;
			Email = email;
			Password = password;
			PhotoPath = photoPath;
		}

		public void AddStore(Exercise exercise)
		{
			if (exercise != null)
			{
				Exercise.Add(exercise);
			}
		}
	}
}
