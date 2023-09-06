using KamchatkaTravel.Domain.Shared.Tours;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class UpdateTourDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public IFormFile? LogoImage { get; set; }
        public SeasonType SeasonType { get; set; }
        public NightType NightType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public IFormFile? DescriptionImage { get; set; }
        public string LinkEquipment { get; set; }
        public bool Visible { get; set; }
    }
}
