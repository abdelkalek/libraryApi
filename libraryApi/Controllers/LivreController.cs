using libraryApi.Infrastructure;
using libraryApi.Infrastructure.Repository;
using libraryApi.Models;
using libraryApi.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libraryApi.Controllers
{
    [Authorize(Roles = "Employe, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly LivreRepository _livreRepository;
        private readonly AuteurRepository _auteurRepository;
        private readonly TypeRepository _typeRepository;
        public LivreController(TypeRepository typeRepository, LivreRepository livreRepository, AuteurRepository auteurRepository)
        {
            _typeRepository = typeRepository;
            _livreRepository = livreRepository;
            _auteurRepository = auteurRepository;
        }

        // GET: api/<LivresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livre>>> GetAsync()
        {
            var items = await _livreRepository.GetAllAsync();
            return Ok(items);
        }

        // GET api/<LivresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livre>> GetByIdAsync(Guid id)
        {
            var item = await _livreRepository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Livre>> PostAsync(LivreDTO livre)
        {


            var existingAuteur = await _auteurRepository.GetAsync(livre.AuteurId);
            if (existingAuteur == null)
            {
                return NotFound(" Auteur Not Exist");
            }
            var existingType = await _typeRepository.GetAsync(livre.TypeId);
            if (existingType == null)
            {
                return NotFound("Type Not Exist ");
            }

            var l  = new Livre
            {
                Titre = livre.Titre,
                ISBN = livre.ISBN,
                Description = livre.Description,
                Auteur = existingAuteur,
                Type= existingType,
            };
            await _livreRepository.CreateAsync(l);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = l.Id }, l);
        }
        //Update /typeCriters
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, LivreDTO livre)
        {


            var existinglivre = await _livreRepository.GetAsync(id);
            if (existinglivre == null)
            {
                return NotFound();
            }

            var existingAuteur = await _auteurRepository.GetAsync(livre.AuteurId);
            if (existingAuteur == null)
            {
                return NotFound(" Author Not Exist");
            }
            var existingType = await _typeRepository.GetAsync(livre.TypeId);
            if (existingType == null)
            {
                return NotFound("Type Not Exist ");
            }

            existinglivre.Titre = livre.Titre;
            existinglivre.ISBN = livre.ISBN;
            existinglivre.Description = livre.Description;
            existinglivre.AuteurID = livre.AuteurId;
            existinglivre.TypeLivreID = livre.TypeId;
            await _livreRepository.UpdateAsync(existinglivre);
            return NoContent();
        }
        //Update /typeCriters
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existinglivre = await _livreRepository.GetAsync(id);
            if (existinglivre == null)
            {
                return NotFound();
            }
            await _livreRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}