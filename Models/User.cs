using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using olympo_webapi.Models;

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
		public string? Phone { get; set; }
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public UserType? Type { get; set; }
		public DateTime? BirthDate { get; set; }
		public string? ImagePath { get; set; }
		public string? Password { get; set; }

		[NotMapped]
		public IFormFile? Image { get; set; }

		[JsonIgnore]
        public ICollection<GymUser>? Gyms { get; set; } 

        [JsonIgnore]
        public ICollection<UserExercise>? Exercises { get; set; } 
	}
}
