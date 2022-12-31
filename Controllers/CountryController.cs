
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Countrys_API.Models;
using Countrys_API.Services;


namespace Countrys_API.Controllers
{
    [Route("api/[controller]")]

    public class CountryController : Controller
    {
        ICountryService countryService;
        CountriesContext countriesContext;

        public CountryController(ICountryService service, CountriesContext db)
        {
            countryService = service;
            countriesContext = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(countryService.Get());
        }
        
        [HttpGet("flag/{id}")]
        public IActionResult GetFlagImage(int id) 
        {
            string flagsPath = @"C:/Users/aaron/Desktop/Portafolio/Countrys-API/Images/Flags/";

            string filePath = Path.Combine(flagsPath + id + ".png");

            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(flagsPath + id + ".png", "image/png");
            }
            else
            {
                return NotFound(); // var country = countryService.GetFlagImage(id).ElementAt(0).Capital;
            }   
        }

        [HttpGet("silhouette/{id}")]
        public IActionResult GetSilHouette(int id)
        {
            /*
            string filePath = Path.Combine(@"C:/Users/aaron/Desktop/Images/" + id + ".png");

            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(@"C:/Users/aaron/Desktop/Images/" + id + ".png", "image/png");
            }
            else
            {
                return NotFound();
            }
            */
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Country country)
        {
            countryService.Save(country);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Country country)
        {
            countryService.Update(id, country);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            countryService.Delete(id);
            return Ok();
        }

        


    }
}
