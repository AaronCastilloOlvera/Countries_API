
using Countrys_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Countrys_API.Services
{
    public class CountryService : ICountryService
    {
        CountriesContext context;

        public CountryService(CountriesContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Country> Get() 
        {
            return context.countries;
        }

        public async Task Save( [FromBody] Country country) 
        {
            context.Add(country);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id) 
        {
            var myCountry = context.countries.Find(id);

            if (myCountry != null) 
            {
                context.Remove(myCountry);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICountryService 
    {
        IEnumerable<Country> Get();

        Task Save(Country country);

        Task Delete(int id);
    }


}
