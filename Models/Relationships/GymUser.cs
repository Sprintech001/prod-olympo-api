using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class GymUser
    {
        [Key]
        public int Id { get; set; }
        public int? GymId { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("GymId")]
        [JsonIgnore]
        public Gym? Gym { get; set; }

        [ForeignKey("UserId")]
        [JsonIgnore]
        public User? User { get; set; }
    }
}