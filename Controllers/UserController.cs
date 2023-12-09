using ASC_TEST.Data;
using ASC_TEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASC_TEST.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public User Create([FromServices] IUserRepository userRepository) {
            User usuario = new() { Email = "email.com", Name = "joao", Password = "123456" };
           userRepository.Save(usuario);
            return usuario;
        }
    }
}
