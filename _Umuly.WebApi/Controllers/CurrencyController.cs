using _Umuly.WebApi.Dto;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _Umuly.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyReposityory _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyController(ICurrencyReposityory currencyRepository,  IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Currency>))]
        public IActionResult GetCurrencies()
        {
            var currencies = _mapper.Map<List<CurrencyDto>>(_currencyRepository.GetCurrencies());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(currencies);
        }

        [HttpGet("{currencyId}")]
        [ProducesResponseType(200, Type = typeof(Currency))]
        [ProducesResponseType(400)]
        public IActionResult GetCurrency(int currencyId)
        {
            if (!_currencyRepository.CurrencyExists(currencyId))
                return NotFound();

            var currency = _mapper.Map<CurrencyDto>(_currencyRepository.GetCurrency(currencyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(currency);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCurrency([FromBody] CurrencyDto currencyCreate)
        {
            if (currencyCreate == null)
                return BadRequest(ModelState);

            var currency = _currencyRepository.GetCurrencies()
                .Where(c => c.CurrencyName.Trim().ToUpper() == currencyCreate.CurrencyName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (currency != null)
            {
                ModelState.AddModelError("", "Currency already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currencyMap = _mapper.Map<Currency>(currencyCreate);

            if (!_currencyRepository.CreateCurrency(currencyMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{currencyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCurrency(int currencyId, [FromBody] CurrencyDto updatedCurrency)
        {
            if (updatedCurrency == null)
                return BadRequest(ModelState);

            if (currencyId != updatedCurrency.Id)
                return BadRequest(ModelState);

            if (!_currencyRepository.CurrencyExists(currencyId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var currencyMap = _mapper.Map<Currency>(updatedCurrency);

            if (!_currencyRepository.UpdateCurrency(currencyMap))
            {
                ModelState.AddModelError("", "Something went wrong updating currency");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{currencyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCurrency(int currencyId)
        {
            if (!_currencyRepository.CurrencyExists(currencyId))
            {
                return NotFound();
            }

            var currencyToDelete = _currencyRepository.GetCurrency(currencyId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currencyRepository.DeleteCurrency(currencyToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting currency");
            }

            return NoContent();
        }
    }
}
