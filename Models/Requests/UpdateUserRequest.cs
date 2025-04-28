namespace olympo_webapi.Models.Requests
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? CPF { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public UserType? Type { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; } 
    }
}
