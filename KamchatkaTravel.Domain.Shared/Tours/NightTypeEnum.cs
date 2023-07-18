using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KamchatkaTravel.Domain.Shared.Tours
{
    public enum NightType
    {
        [Display(Name = "")]
        defaultValue = 0,

        [Display(Name = "в палатках и квартире")]
        TentAndFlat = 1,

        [Display(Name = "в палатках и отеле")]
        TentAndHotel = 2,

        [Display(Name = "в глэмпинге и отеле")]
        GlampingAndHotel = 3,

        [Display(Name = "без ночевкиц")]
        withoutNight = 4
    }

}
