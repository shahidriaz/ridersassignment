using System.Security.Cryptography;
using System.Text;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _dataContext;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext dataContext, ITokenService tokenService)
        {
            _dataContext = dataContext;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (!await UserExists(registerDTO.UserName))
            {
                using var hmac = new HMACSHA512();
                var user = new AppUser()
                {
                    UserName = registerDTO.UserName.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
                    PasswordSalt = hmac.Key
                };
                _dataContext.Users.Add(user);
                await _dataContext.SaveChangesAsync();
                return new UserDTO()
                {
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
            else
            {
                return BadRequest(string.Format("User Name : {0} already exists", registerDTO.UserName));
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDTO.UserName);
            if (user == null) return Unauthorized();
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized();
            }
            return new UserDTO()
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string userName)
        {
            return await this._dataContext.Users.AnyAsync(x => x.UserName == userName.ToLower());
        }
    }
}