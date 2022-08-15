using _Umuly.WebApi.Dto;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _Umuly.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteOwnerController : Controller
    {
        private readonly IQuoteOwnerRepository _quoteOwnerRepository;
        private readonly IMapper _mapper;

        public QuoteOwnerController(IQuoteOwnerRepository quoteOwnerRepository, IMapper mapper)
        {
            _quoteOwnerRepository = quoteOwnerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuoteOwner>))]
        public IActionResult GetQuoteOwners()
        {
            var quoteOwners = _mapper.Map<List<QuoteOwnerDto>>(_quoteOwnerRepository.GetQuoteOwners());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(quoteOwners);
        }

        [HttpGet("{quoteOwnerId}")]
        [ProducesResponseType(200, Type = typeof(QuoteOwner))]
        [ProducesResponseType(400)]
        public IActionResult GetQuoteOwner(int quoteOwnerId)
        {
            if (!_quoteOwnerRepository.QuoteOwnerExists(quoteOwnerId))
                return NotFound();

            var quoteOwner = _mapper.Map<QuoteOwnerDto>(_quoteOwnerRepository.GetQuoteOwner(quoteOwnerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(quoteOwner);
        }
        [HttpGet("{email}")]
        [ProducesResponseType(200, Type = typeof(QuoteOwner))]
        [ProducesResponseType(400)]
        public IActionResult GetQuoteOwnerByEmail(string email)
        {
            if (!_quoteOwnerRepository.QuoteOwnerExistsByEmail(email))
                return NotFound();

            var quoteOwner = _mapper.Map<QuoteOwnerDto>(_quoteOwnerRepository.GetQuoteOwnerByEmail(email));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(quoteOwner);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuoteOwner([FromBody] QuoteOwnerDto quoteOwnerCreate)
        {
            if (quoteOwnerCreate == null)
                return BadRequest(ModelState);

            var quoteOwner = _quoteOwnerRepository.QuoteOwnerExists(quoteOwnerCreate.Id);

            if (quoteOwner)
            {
                ModelState.AddModelError("", "QuoteOwner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var quoteOwnerMap = _mapper.Map<QuoteOwner>(quoteOwnerCreate);

            if (!_quoteOwnerRepository.CreateQuoteOwner(quoteOwnerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{quoteOwnerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateQuoteOwner(int quoteOwnerId, [FromBody] QuoteOwnerDto updatedQuoteOwner)
        {
            if (updatedQuoteOwner == null)
                return BadRequest(ModelState);

            if (quoteOwnerId != updatedQuoteOwner.Id)
                return BadRequest(ModelState);

            if (!_quoteOwnerRepository.QuoteOwnerExists(quoteOwnerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var quoteOwnerMap = _mapper.Map<QuoteOwner>(updatedQuoteOwner);

            if (!_quoteOwnerRepository.UpdateQuoteOwner(quoteOwnerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{quoteOwnerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteQuoteOwner(int quoteOwnerId)
        {
            if (!_quoteOwnerRepository.QuoteOwnerExists(quoteOwnerId))
            {
                return NotFound();
            }

            var quoteOwnerToDelete = _quoteOwnerRepository.GetQuoteOwner(quoteOwnerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_quoteOwnerRepository.DeleteQuoteOwner(quoteOwnerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting quote owner");
            }

            return NoContent();
        }
    }
}
