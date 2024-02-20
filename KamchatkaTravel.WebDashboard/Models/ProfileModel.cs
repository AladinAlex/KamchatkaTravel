namespace KamchatkaTravel.WebDashboard.Models
{
    public class ProfileModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        
        public int? PersonTelegram_Id { get; set; }
        public int? Chat_id { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
