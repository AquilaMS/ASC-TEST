using ASC_TEST.Data;
using ASC_TEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASC_TEST.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : Controller
    {
        [HttpPost(Name = "signup")]
        public SimpleMessageDTO Signup([FromServices] IUserRepository userRepository, [FromBody]SigninDTO signin) {
            SimpleMessageDTO simpleMessage = new("User inserted");
            User user = new() { Email = signin.Email, Name = signin.Name, Password = signin.Password };
            if(userRepository.FindByEmailAndName(user) == null){
                userRepository.Save(user);
                simpleMessage = new("User inserted");
            }else{
                simpleMessage = new("User not inserted");
            };
             return simpleMessage;
        }
        [HttpGet]
        public TokenDTO Signin(TokenService tokenService) {
            User usuario = new() { Email = "email.com", Name = "joao", Password = "123456" };
            TokenDTO token = new(tokenService.Generate(usuario));
            return token;
        }
    }
}
