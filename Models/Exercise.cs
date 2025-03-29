using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class Exercise
    {
        internal readonly int Repetitions;
        internal readonly int Series;
        internal readonly double Breaks;
        internal readonly double Time;

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }

        public int? UserId { get; set; }  

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public List<Session>? Sessions { get; set; } = new List<Session>();
        public List<ExerciseDay>? ExerciseDays { get; set; } = new List<ExerciseDay>();

        [NotMapped]
        public IFormFile? Image { get; set; }

        [NotMapped]
        public IFormFile? Video { get; set; }
    }

}