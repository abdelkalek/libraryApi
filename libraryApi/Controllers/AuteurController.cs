using libraryApi.Infrastructure.Repository;
using libraryApi.Infrastructure;
using libraryApi.Models.Dtos;
using libraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libraryApi.Controllers
{
    [Authorize(Roles = "Employe, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly AuteurRepository _auteurRepository;

        public AuteurController(AuteurRepository auteurRepository)
        {

            _auteurRepository = auteurRepository;
        }

        // GET: api/<AuteursController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auteur>>> GetAsync()
        {
            var items = await _auteurRepository.GetAllAsync();
            return Ok(items);
        }

        // GET api/<AuteursController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auteur>> GetByIdAsync(Guid id)
        {
            var item = await _auteurRepository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Auteur>> PostAsync(AuteurDTO a)
        {
            var auteur = new Auteur
            {
                Nom = a.Nom,
                Prenom = a.Prenom,
            };
            await _auteurRepository.CreateAsync(auteur);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = auteur.Id }, auteur);
        }
        //Update /typeCriters
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, AuteurDTO auteur)
        {
            var existingAuteur = await _auteurRepository.GetAsync(id);
            if (existingAuteur == null)
            {
                return NotFound();
            }
            existingAuteur.Nom = auteur.Nom;
            existingAuteur.Prenom = auteur.Prenom;
            await _auteurRepository.UpdateAsync(existingAuteur);
            return NoContent();
        }
        //Update /typeCriters
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existingAuteur = await _auteurRepository.GetAsync(id);
            if (existingAuteur == null)
            {
                return NotFound();
            }
            await _auteurRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}