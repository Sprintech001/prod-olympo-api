using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class ExerciseDay
	{
		[Key]
		public int Id { get; set; }
		public int ExerciseId { get; set; }
		public string DayOfWeek { get; set; } 
		public int SessionId { get; set; }
		public int UserId { get; set; }
	}
}
