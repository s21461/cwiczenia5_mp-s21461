﻿using System;
using System.Collections.Generic;

#nullable disable

namespace cwiczenia5_mp_s21461.Models
{
    public partial class CountryTrip
    {
        public int IdCountry { get; set; }
        public int IdTrip { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
    }
}
