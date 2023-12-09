using ASC_TEST.Data;
using ASC_TEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASC_TEST.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : Controller
    {
        [HttpPost]
        public User Create([FromServices] IUserRepository userRepository) {
            User usuario = new() { Email = "email.com", Name = "joao", Password = "123456" };
            
            userRepository.Save(usuario);
            return usuario;
        }
        [HttpGet]
        public TokenDTO GetToken(TokenService tokenService) {
            User usuario = new() { Email = "email.com", Name = "joao", Password = "123456" };
            TokenDTO token = new TokenDTO(tokenService.Generate(usuario));
            return token;
        }
    }
}
