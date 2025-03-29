using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class Session
    {
		internal int Day;

		[Key]
        public int Id { get; set; }
        public int Repetitions { get; set; }
        public int Series { get; set; }
        public double Breaks { get; set; }
        public double Time { get; set; }
        public int ExerciseId { get; set; }

        [ForeignKey("ExerciseId")]
        [JsonIgnore]
        public Exercise? Exercise { get; set; }
    }
}
