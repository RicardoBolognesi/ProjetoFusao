using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Domains.Interfaces.Service;

namespace ProjetoTeste2.App.Controllers
{
    [Produces("application/json")]
    [Route("UserAPI")]
    public class UserController : ControllerBase
    {
        private readonly IRequestInfoHelper _requestInfoHelper;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IRequestInfoHelper requestInfoHelper, UserManager<User> userManager, IUserService userService, IMapper mapper)
        {
            _requestInfoHelper = requestInfoHelper;
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
        }

        [Route("SaveUser")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            string ass = "Registro Criado com Sucesso !";
            string msg = "<p><b><font color='red'>CREDENCIAIS DE ACESSO :</font></b></p>" +
                         "<p><b>Usuário : </b>" + userDto.UserName + " . </p>" +
                         "<p><b>Senha   : </b>" + userDto.PasswordHash + ". </p>";



            var usuario = new User()
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash
            };

            try
            {
                var result = await _userManager.CreateAsync(usuario, userDto.PasswordHash);
                _userService.EnviarEmail(usuario.Email, ass, msg);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}