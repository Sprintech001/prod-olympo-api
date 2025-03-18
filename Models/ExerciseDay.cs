using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class ExerciseDay
	{
		[Key]
		public int Id { get; set; }

		public int ExerciseId { get; set; }
		public int DayOfWeek { get; set; } 

		[ForeignKey("ExerciseId")]
		public Exercise? Exercise { get; set; }
	}
}
