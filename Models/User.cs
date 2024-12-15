using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class User
	{
		[Key]
		public int Id { get;  set; }
		public string CPF { get; set; }
		public string Name { get; set; }
		public string Email { get;  set; }
		public string ?Photo { get; set; }
		public string Password { get;	set; }
		public List<Exercise> Exercise { get; set; } = new List<Exercise>();

		public User() { }

		
		public User(string cpf, string name, string email, string photo, string password)
		{
			CPF = cpf;
			Name = name;
			Email = email;
			Photo = photo;
			Password = password;
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
