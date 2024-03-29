﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamchatkaTravel.Identity.Models
{
    public class IdentityPerson : IdentityUser
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Comment { get; set; }
        public PersonTelegram? PersonTelegram { get; set; }
    }
}
