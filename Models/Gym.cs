using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace olympo_webapi.Models
{
    public class Gym
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; } 
        public string? Code { get; set; } 
        public string? Address { get; set; } 
        public string? PhoneNumber { get; set; } 
        public string? Email { get; set; } 
        public string? Website { get; set; } 
        public string? Description { get; set; } 
        public string? ImageUrl { get; set; } 

        [JsonIgnore]
        public ICollection<GymUser>? Users { get; set; }
    }
}