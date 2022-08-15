using _Umuly.WebApi.Dto;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _Umuly.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : Controller
    {

        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;
        private readonly ICurrencyReposityory _currencyRepository;

        public QuoteController(ICurrencyReposityory currencyRepository, IQuoteRepository quoteRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _quoteRepository = quoteRepository;
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Quote>))]
        public IActionResult GetQuotes()
        {
            var quotes = _mapper.Map<List<QuoteDto>>(_quoteRepository.GetQuotes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(quotes);
        }

        [HttpGet("{quoteId}")]
        [ProducesResponseType(200, Type = typeof(Quote))]
        [ProducesResponseType(400)]
        public IActionResult GetQuote(int quoteId)
        {
            if (!_quoteRepository.QuoteExists(quoteId))
                return NotFound();

            var quote = _mapper.Map<QuoteDto>(_quoteRepository.GetQuote(quoteId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(quote);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuote([FromBody] QuoteDto quoteCreate)
        {
            if (quoteCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var quoteMap = _mapper.Map<Quote>(quoteCreate);

            if (!_quoteRepository.CreateQuote(quoteMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        
        [HttpPut("{quoteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCity(int quoteId, [FromBody] QuoteDto updatedCity)
        {
            if (updatedCity == null)
                return BadRequest(ModelState);

            if (quoteId != updatedCity.Id)
                return BadRequest(ModelState);

            if (!_cityRepository.CityExists(quoteId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var quoteMap = _mapper.Map<Quote>(updatedCity);

            if (!_quoteRepository.UpdateQuote(quoteMap))
            {
                ModelState.AddModelError("", "Something went wrong updating quote");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
     
        [HttpDelete("{quoteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteQuote(int quoteId)
        {
            if (!_quoteRepository.QuoteExists(quoteId))
            {
                return NotFound();
            }

            var quoteToDelete = _quoteRepository.GetQuote(quoteId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_quoteRepository.DeleteQuote(quoteToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting quote");
            }

            return NoContent();
        }
      
    }
}
