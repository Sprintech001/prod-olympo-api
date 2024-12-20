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

		public Session(int repetitions, int series, double time)
		{
			if (repetitions < 0) throw new ArgumentException("As repetições não podem ser negativas.");
			if (series < 0) throw new ArgumentException("As series não podem ser negativas.");
			if (time < 0) throw new ArgumentException("O tempo não podem ser negativo.");

			Repetitions = repetitions;
			Series = series;
			Time = time;
		}

		public void UpdateSession(int repetitions, int series, double time)
		{
			if (repetitions < 0) throw new ArgumentException("As repetições não podem ser negativas.");
			if (series < 0) throw new ArgumentException("As series não podem ser negativas.");
			if (time < 0) throw new ArgumentException("O tempo não podem ser negativo.");

			Repetitions = repetitions;
			Series = series;
			Time = time;
		}
	}
}
