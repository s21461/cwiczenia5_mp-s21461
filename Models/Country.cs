﻿using System;
using System.Collections.Generic;

#nullable disable

namespace cwiczenia5_mp_s21461.Models
{
    public partial class Country
    {
        public Country()
        {
            CountryTrips = new HashSet<CountryTrip>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CountryTrip> CountryTrips { get; set; }
    }
}
