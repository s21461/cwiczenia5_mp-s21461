using System;

namespace cwiczenia5_mp_s21461.Models.DTO
{
    public class ClientRequestForTrip
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Pesel { get; set; }
        public int IdTrip { get; set; }
        public string Name { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
