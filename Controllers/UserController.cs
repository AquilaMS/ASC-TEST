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
        public SimpleMessageDTO Signup([FromServices] IUserRepository userRepository, [FromBody] SignDTO signup)
        {
            SimpleMessageDTO simpleMessage = new("");
            User user = new() { Email = signup.Email, Name = signup.Name, Password = signup.Password };
            if (userRepository.FindByEmailAndName(user) == null)
            {
                userRepository.Save(user);
                simpleMessage = new("User inserted");
            }
            else
            {
                simpleMessage = new("User not inserted");
            };
            return simpleMessage;
        }
        [HttpGet]
        public TokenDTO Signin([FromServices] IUserRepository userRepository, PasswordService passwordService, TokenService tokenService, [FromBody] SignDTO signin)
        {
            User user = new() { Email = signin.Email, Name = signin.Name, Password = signin.Password };
            try
            {
                User gotUser = userRepository.FindByEmailAndName(user);
                System.Diagnostics.Debug.WriteLine(gotUser);
                if (gotUser != null && passwordService.DecodeHashPassword(user.Password, gotUser.Password))
                {
                    TokenDTO token = new(tokenService.Generate(gotUser));
                    return token;
                };
            }
            catch
            {
                return new TokenDTO("Error");
            }
            return new TokenDTO("Error");

        }
    }
}
