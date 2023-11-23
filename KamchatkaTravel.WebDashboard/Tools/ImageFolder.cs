namespace KamchatkaTravel.WebDashboard.Tools
{
    public static class ImageFolder
    {
        private static Dictionary<Folder, string> folders = new Dictionary<Folder, string>()
        {
            {Folder.Review, "Review" }, {Folder.Tour, "Tour"}, {Folder.Day, "Day"}
        };
        public static string Get(Folder folder)
        {
            return folders[folder];
        }
    }

    public enum Folder
    {
        Review = 1,
        Tour = 2,
        Day = 3,
    }
}
