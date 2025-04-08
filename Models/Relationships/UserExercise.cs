using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class UserExercise
    {
        [Key]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ExerciseId { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public User? User { get; set; }

        [ForeignKey("ExerciseId")]
        [JsonIgnore]
        public Exercise? Exercise { get; set; }
    }
}