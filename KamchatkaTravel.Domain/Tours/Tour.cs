using KamchatkaTravel.Domain.Common;
using KamchatkaTravel.Domain.Shared.Tours;

namespace KamchatkaTravel.Domain.Tours
{
    [Serializable]
    public class Tour : BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; } = string.Empty; // слоган - "Программа по чек-листу « Что нужно сделать на Камчатке»." (пример)
        //public int? AgeLimit { get; set; }
        //public int DurationDays { get; set; }
        //public byte[] LogoImage { get; set; }
        public string LogoImageUrl { get; set; }
        public SeasonType SeasonType { get; set; }
        public NightType NightType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string DescriptionImageUrl { get; set; }
        public string LinkEquipment { get; set; }
        public string RouteName { get; set; }
        
        public List<Day> Days { get; set; }
        public List<Image> Images { get; set; }
        public List<Include> Includes { get; set; }
        public List<Question> Questions { get; set; }
        public List<View> Views { get; set; }
    }
}
