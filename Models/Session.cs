using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class Session
    {
        [JsonInclude]
        public int Day { get; set; }

		[Key]
        public int Id { get; set; }
        public int Repetitions { get; set; }
        public int Series { get; set; }
        public double Breaks { get; set; }
        public double Time { get; set; }
        public int ExerciseId { get; set; }

        public int? UserId { get; set; }
        
        [ForeignKey("ExerciseId")]
        public Exercise? Exercise { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
