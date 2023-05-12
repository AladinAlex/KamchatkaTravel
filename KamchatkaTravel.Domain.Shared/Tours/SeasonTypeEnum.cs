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
        All = 0,

        Summer = 1,

        Autumn = 2,

        Winter = 3,

        Spring = 4

    }
}
