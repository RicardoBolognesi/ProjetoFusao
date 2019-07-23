using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces;
using ProjetoTeste2.Domains.Interfaces.Repository;

namespace ProjetoTeste2.App.Controllers
{
    [Produces("application/json")]
    [Route("UserAPI")]
    public class UserController : ControllerBase
    {
        private readonly IRequestInfoHelper _requestInfoHelper;
        private readonly UserManager<User> _userManager;

        public UserController(IRequestInfoHelper requestInfoHelper, UserManager<User> userManager)
        {
            _requestInfoHelper = requestInfoHelper;
            _userManager = userManager;
        }

        [Route("SaveUser")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            BaseResponseDto baseResponseDTO = new BaseResponseDto();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);
            
            var usuario = new User()
            {
               
                UserName = userDto.UserName,
                Email = userDto.Email
            };

            try
            {
                var result = await _userManager.CreateAsync(usuario, userDto.Password);
                baseResponseDTO.IsSuccess = result.Succeeded;
                HttpContext.Session.SetString("SignedInTime", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));
                baseResponseDTO.Message = result.ToString();

            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }
            return Ok(baseResponseDTO);
        }

    }
}