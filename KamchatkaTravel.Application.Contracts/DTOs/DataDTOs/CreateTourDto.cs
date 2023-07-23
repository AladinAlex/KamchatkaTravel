using KamchatkaTravel.Domain.Shared.Tours;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class CreateTourDto
    {
        public string? Name { get; set; }
        public string? Tagline { get; set; } = string.Empty; // слоган - "Программа по чек-листу « Что нужно сделать на Камчатке»." (пример)
        public IFormFile? LogoImg { get; set; }
        public SeasonType? SeasonType { get; set; }
        public NightType? NightType { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public IFormFile? DescriptionImg { get; set; }
        public string? LinkEquipment { get; set; }
    }
}
