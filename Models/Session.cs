using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class Session
	{
		[Key]
		public int Id { get; set; }
		public int Repetitions { get; set; }
		public int Series { get; set; }
		public double Time { get; set; } 
	}
}
