using cwiczenia5_mp_s21461.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cwiczenia5_mp_s21461.Models.DTO;
using cwiczenia5_mp_s21461.Services;

namespace cwiczenia5_mp_s21461.Services
{
    public class DbService : IDbService
    {
        private readonly PJATKContext _dbContext;
        public DbService(PJATKContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<SomeSortOfTrips>> GetTrips()
        {

            return await _dbContext.Trips
                .Include(e => e.CountryTrips)
                .Include(e => e.ClientTrips)
                .Select(e => new SomeSortOfTrips
                {
                    Name = e.Name,
                    Description = e.Description,
                    MaxPeople = e.MaxPeople,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    Countries = e.CountryTrips.Select(e => new SomeSortOfCountry { Name = e.IdCountryNavigation.Name }).ToList(),
                    Clients = e.ClientTrips.Select(e => new SomeSortOfClient { FirstName = e.IdClientNavigation.FirstName, LastName = e.IdClientNavigation.LastName })
                }).OrderByDescending(e => e.DateFrom)
                .ToListAsync();

        }

        public async Task<int> AddClientToTrip(ClientRequestForTrip client, int idTrip)
        {
            var result = await _dbContext.Clients.Where(e => e.Pesel == client.Pesel).FirstOrDefaultAsync();
            if (result == null)
            {
                var addClient = new Client
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Telephone = client.Telephone,
                    Pesel = client.Pesel
                };
                await _dbContext.Clients.AddAsync(addClient);
                await _dbContext.SaveChangesAsync();
            }

            if (!await _dbContext.Trips.AnyAsync(e => e.IdTrip == idTrip))
            {
                return 1;
            }

            if (await _dbContext.ClientTrips.AnyAsync(e => e.IdClient == result.IdClient && e.IdTrip == idTrip))
            {
                return 2;
            }



            await _dbContext.ClientTrips.AddAsync(new ClientTrip
            {
                IdClient = result.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = client.PaymentDate
            });


            await _dbContext.SaveChangesAsync();
            return 0;
        }


        public async Task<int> RemoveClient(int id)
        {
            var result = await _dbContext.ClientTrips.Where(e => e.IdClient == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return 1;
            }

            var client = new Client { IdClient = id };
            _dbContext.Attach(client);
            _dbContext.Remove(client);

            await _dbContext.SaveChangesAsync();

            return 0;
        }
    }
}
