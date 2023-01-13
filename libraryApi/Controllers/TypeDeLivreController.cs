using libraryApi.Infrastructure.Repository;
using libraryApi.Models.Dtos;
using libraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libraryApi.Controllers
{
    [Authorize(Roles = "Employe, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeDeLivreController : ControllerBase
    {
        private readonly TypeRepository _typeRepository;

        public TypeDeLivreController(TypeRepository typeRepository)
        {

            _typeRepository = typeRepository;
        }

        // GET: api/<TypeLivresController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeLivre>>> GetAsync()
        {
            var items = await _typeRepository.GetAllAsync();
            return Ok(items);
        }

        // GET api/<TypeLivresController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeLivre>> GetByIdAsync(Guid id)
        {
            var item = await _typeRepository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<TypeLivre>> PostAsync(TypeLivreDTO t)
        {
            var TypeLivre = new TypeLivre
            {
               Designation = t.Designation
            };
            await _typeRepository.CreateAsync(TypeLivre);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = TypeLivre.Id }, TypeLivre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, TypeLivreDTO tLivre)
        {
            var existingTypeLivre = await _typeRepository.GetAsync(id);
            if (existingTypeLivre == null)
            {
                return NotFound();
            }
            existingTypeLivre.Designation = tLivre.Designation;
            await _typeRepository.UpdateAsync(existingTypeLivre);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var existingTypeLivre = await _typeRepository.GetAsync(id);
            if (existingTypeLivre == null)
            {
                return NotFound();
            }
            await _typeRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
