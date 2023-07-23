﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Application.Contracts.DTOs.DataDTOs
{
    public class SimpleTour
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class GetToursResponse
    {
        public IEnumerable<SimpleTour> tours { get; set; }
    }
}
