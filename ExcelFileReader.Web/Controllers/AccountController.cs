using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExcelFileReader.Core.DTO;
using ExcelFileReader.Core.Services.Interfaces;
using ExcelFileReader.Helper;
using ExcelFileReader.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExcelFileReader.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;
       private readonly IJwtAuthManager _jwtAuthManager;
        public AccountController(IUserService userService, IJwtAuthManager jwtAuthManager, ILogger<AccountController> logger)
        {
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_userService.GetUser(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            //var role = _userService.GetUserRole(request.UserName);
            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name,request.UserName),
            //    new Claim(ClaimTypes.Role, role)
            //};
            var claims = new[]
           {
                new Claim(ClaimTypes.Name,request.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.UserName}] logged in the system.");
            return Ok(new LoginResult
            {
                UserName = request.UserName,
                Role = "Admin",
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString,
                ExpireIn=string.Format("Token Expires in {0}",jwtResult.ExpireIn)
            });
        }
    }
}