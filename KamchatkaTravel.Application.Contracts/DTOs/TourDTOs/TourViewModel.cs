﻿using KamchatkaTravel.Domain.Shared.Tours;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.TourDTOs
{
    public class TourViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string LogoImageUrl { get; set; }
        public IFormFile? LogoImageFile { get; set; }
        public SeasonType SeasonType { get; set; }
        public NightType NightType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string DescriptionImageUrl { get; set; }
        public IFormFile? DescriptionImageFile { get; set; }
        public string LinkEquipment { get; set; }
        public bool Visible { get; set; }
        public DateTime CreateDt { get; set; }
        public List<ViewModel> views { get; set; }
        public List<ImageModel> images { get; set; }
        public List<DayModel> days { get; set; }
        public List<QuestionModel> questions { get; set; }
        public List<IncludeModel> includes { get; set; }
    }
}
