﻿namespace KamchatkaTravel.WebDashboard.Models
{
    public class SignInModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
