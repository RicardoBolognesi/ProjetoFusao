using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Infra;

namespace ProjetoTeste2.App.Controllers
{
    [Produces("application/json")]
    [Route("AccountAPI")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IRequestInfoHelper _requestInfoHelper;
        private readonly AuthenticatedUser _user;

        public LoginController(SignInManager<User> signInManager, IRequestInfoHelper requestInfoHelper, AuthenticatedUser user, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _requestInfoHelper = requestInfoHelper;
            _user = user;
            _userManager = userManager;
        }



        //public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        //{
        //    BaseResponseDto baseResponseDTO = new BaseResponseDto();
        //    _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);


        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, false, false);
        //        baseResponseDTO.IsSuccess = result.Succeeded;
        //        HttpContext.Session.SetString("SignedInTime", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss"));
        //        baseResponseDTO.Message = result.ToString();
        //        baseResponseDTO.Response = "true";


        //    }
        //    catch (Exception ex)
        //    {
        //        baseResponseDTO.IsSuccess = false;
        //        baseResponseDTO.Message = ex.Message;
        //    }
        //    return Ok(baseResponseDTO);
        //}

        [Route("SignIn")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            
            if (await DoLogin(signInDto))
            {
                return Ok();
            }
            return BadRequest();
        }
        private async Task<bool> DoLogin(SignInDto signInDto)
        {
            User user = await _userManager.FindByNameAsync(signInDto.UserName);
            
            if (user != null)
            {
                await _signInManager.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(user, signInDto.Password,
                        false, false);
                return result.Succeeded;
            }
            return false;
        }


        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {


            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //[Route("GetSignedInUser")]
        //public IActionResult GetSignedInUser()
        //{
        //    BaseResponseDto baseResponseDTO = new BaseResponseDto();
        //    _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);

        //    try
        //    {
        //        User userDTO = new User();
        //        userDTO.UserName = User.Identity.Name;
        //        baseResponseDTO.Response = JsonConvert.SerializeObject(userDTO);
        //        baseResponseDTO.IsSuccess = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        baseResponseDTO.IsSuccess = false;
        //        baseResponseDTO.Message = ex.Message;

        //    }
        //        return Ok(baseResponseDTO);
        //}
        [Route("GetSignedInUser")]
        public IActionResult GetSignedInUser()
        {
            UserAuthenticated user = new UserAuthenticated();
            user.Authenticated = User.Identity.IsAuthenticated;
            user.UserName = User.Identity.Name;
            return Ok(user);
        }

        [Route("ObterNomeUsuario")]
        public IActionResult ObterNomeUsuario()
        {
            try
            {
                UserAuthenticated user = new UserAuthenticated();
                user.Authenticated = User.Identity.IsAuthenticated;
                user.UserName = User.Identity.Name;
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}