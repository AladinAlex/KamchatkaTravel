    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KamchatkaTravel.Domain.Shared.Tours
{
    /// <summary>
    /// Время года для туров
    /// </summary>
    public enum SeasonType
    {
        [Display(Name = "Все")]
        All = 0,
        [Display(Name = "Лето")]
        Summer = 1,
        [Display(Name = "Осень")]
        Autumn = 2,
        [Display(Name = "Зима")]
        Winter = 3,
        [Display(Name = "Весна")]
        Spring = 4
    }
}
