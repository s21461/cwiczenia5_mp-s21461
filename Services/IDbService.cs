using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using cwiczenia5_mp_s21461.Models;
using cwiczenia5_mp_s21461.Models.DTO;

namespace cwiczenia5_mp_s21461.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<SomeSortOfTrips>> GetTrips();
        public Task<int> RemoveClient(int id);

        public Task<int> AddClientToTrip(ClientRequestForTrip client, int idTrip);
    }
}
