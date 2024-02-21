using Server.Models.Users;
using Server.Repositories.Users.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsers_Repo UsersRepo;
        public LoginController(IUsers_Repo repo)
        {
            UsersRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await UsersRepo.SignUp(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return StatusCode(500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var result = await UsersRepo.SignIn(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [HttpGet("GetIdByUserName")]
        public async Task<string> GetIdByUserName(string username)
        {
            return await UsersRepo.GetIdByNameIdentifier(username);
        }
    }
}
