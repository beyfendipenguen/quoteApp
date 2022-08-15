using _Umuly.WebApi.Dto;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _Umuly.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CityController(ICityRepository cityRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<City>))]
        public IActionResult GetCities()
        {
            var cities = _mapper.Map<List<CityWithCountry>>(_cityRepository.GetCities());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cities);
        }

        [HttpGet("{cityId}")]
        [ProducesResponseType(200, Type = typeof(City))]
        [ProducesResponseType(400)]
        public IActionResult GetCity(int cityId)
        {
            if (!_cityRepository.CityExists(cityId))
                return NotFound();

            var city = _mapper.Map<CityDto>(_cityRepository.GetCity(cityId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(city);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCity([FromQuery] int countryId, [FromBody] CityDto cityCreate)
        {
            if (cityCreate == null)
                return BadRequest(ModelState);

            var city = _cityRepository.GetCities()
                .Where(c => c.CityName.Trim().ToUpper() == cityCreate.CityName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (city != null)
            {
                ModelState.AddModelError("", "City already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cityMap = _mapper.Map<City>(cityCreate);
            cityMap.CountryId = countryId;

            if (!_cityRepository.CreateCity(cityMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{cityId}/Country/{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCity(int cityId, int countryId, [FromBody] CityDto updatedCity)
        {
            if (updatedCity == null)
                return BadRequest(ModelState);

            if (cityId != updatedCity.Id)
                return BadRequest(ModelState);

            if (!_cityRepository.CityExists(cityId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var cityMap = _mapper.Map<City>(updatedCity);
            cityMap.CountryId = countryId;

            if (!_cityRepository.UpdateCity(cityMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{cityId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCity(int cityId)
        {
            if (!_cityRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var cityToDelete = _cityRepository.GetCity(cityId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_cityRepository.DeleteCity(cityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting city");
            }

            return NoContent();
        }
    }
}
