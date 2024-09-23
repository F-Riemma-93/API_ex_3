using API_ex_3.Models;
using API_ex_3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace API_ex_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly UserService _userService;

        public UserLoginController(UserService userService)
        {
            _userService = userService;
        }

        // API per la registrazione
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var result = _userService.Register(user);
            if (result == "OK")
            {
                return Ok();
            }
            return BadRequest();
        }
        // API per il login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Models.LoginRequest request)
        {
            var user = _userService.Login(request.Username, request.Password);
            if (user != null)
            {
                return Ok(user);  // Se il login ha successo, restituisci l'utente
            }
            return Unauthorized();
        }

    }
}
