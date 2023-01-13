using libraryApi.Models;
using libraryApi.Models.Dtos;
using libraryApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace libraryApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmployeController(IAuthService authService, UserManager<ApplicationUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("AddEmploye")]
        public async Task<IActionResult> AddEmployeAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet("GetAllEmployes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<ApplicationUser>> Get()
        {
            try
            {
                var ListUsers = await _userManager.Users.ToListAsync();
                return ListUsers;
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {

                var user = await _userManager.Users.FirstOrDefaultAsync(user => user.Id == id);
                if (user != null)
                {
                    return Ok(user);
                }
                return BadRequest();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        [HttpPut("EditEmploye/{id}")]
        public async Task<ApplicationUser> EditEmploye(string id, [FromBody] UpdateEmploye e)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    user.Nom = e.Nom;
                    user.Prenom = e.Prenom;
                    user.UserName = e.Username;
                    user.Email = e.Email;
                    await _userManager.UpdateAsync(user);
                    await _userManager.UpdateNormalizedEmailAsync(user);
                    await _userManager.UpdateNormalizedUserNameAsync(user);
                    await _userManager.UpdateSecurityStampAsync(user);
                    return user;

                }
                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

        }




        [HttpDelete("DeleteEmploye/{id}")]
        public async Task<ActionResult> DeleteEmploye(string id)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    var res = await _userManager.DeleteAsync(user);
                    return Ok(res);
                }
                return BadRequest(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
    }
}