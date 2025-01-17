using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }
        public int? Day { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public List<Session>? Sessions { get; set; } = new List<Session>();

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        
        [NotMapped]
        public IFormFile? Video { get; set; }
    }
}