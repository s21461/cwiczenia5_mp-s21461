using System;
using System.Collections.Generic;

namespace cwiczenia5_mp_s21461.Models.DTO
{
    public class SomeSortOfTrips
    {
        public string Name { get; set; }    
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public IEnumerable<SomeSortOfClient> Clients { get; set; }
        public IEnumerable<SomeSortOfCountry> Countries { get; set; }
      
    }
}
