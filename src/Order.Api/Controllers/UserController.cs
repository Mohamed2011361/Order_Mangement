using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Order.Core.Dto;
using Order.Core.Entites;
using Order.Core.Interfaces;

namespace Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ItokenServices _tokenServices;

        public UserController(UserManager<AppUser>userManager,SignInManager<AppUser>signInManager,ItokenServices tokenServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto dto)
        {
            var user =await _userManager.FindByEmailAsync(dto.Email);
            if (user is null) return Unauthorized();
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password,false);
            if (result is null || result.Succeeded==false) return Unauthorized();
            return Ok( new UserDto
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token=_tokenServices.CreateToken(user)
            });
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterDto dto)
        {
            var user = new AppUser
            {
                DisplayName=dto.DisplayName,
                UserName=dto.Email,
                Email=dto.Email,

            };
            var result = await _userManager.CreateAsync(user,dto.Password);
            if (result.Succeeded == false) return BadRequest();
            return Ok(new UserDto
            {
                DisplayName=dto.DisplayName,
                Email=dto.Email,
                Token=_tokenServices.CreateToken(user)
            });
        }
        [Authorize]
        [HttpGet("test")]
        public ActionResult<string> Test()
        {
            return "hi";
        }

       

    }
}
