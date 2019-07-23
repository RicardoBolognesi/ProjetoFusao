using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Domains.Interfaces.Service;

namespace ProjetoTeste2.App.Controllers
{
    [Produces("application/json")]
    [Route("EnderecoTipoAPI")]
    public class EnderecoTipoController : ControllerBase
    {
        private readonly IRequestInfoHelper _requestInfoHelper;
        private readonly IEnderecoTipoService _enderecoTipoService;

        public EnderecoTipoController(IEnderecoTipoService enderecoTipoService, IRequestInfoHelper requestInfoHelper)
        {
            _enderecoTipoService = enderecoTipoService;
            _requestInfoHelper = requestInfoHelper;
        }


        [Route("GetAll")]
        public IActionResult GetAll()
        {
            BaseResponseDto baseResponseDTO = new BaseResponseDto();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);
            IList<EnderecoTipo> enderecoTipoDtos = new List<EnderecoTipo>();
            try
            {
                enderecoTipoDtos = _enderecoTipoService.GetTodos();
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(enderecoTipoDtos);
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }
            return Ok(baseResponseDTO);

        }
        [Route("Create")]
        public IActionResult Create([FromBody]EnderecoTipoDto enderecoTipoDto)
        {

            EnderecoTipo enderecoTipo = new EnderecoTipo();
            try
            {
                enderecoTipo.EnderecoTipoId = enderecoTipoDto.EnderecoTipoId;
                enderecoTipo.DescricaoTipo = enderecoTipoDto.DescricaoTipo;

                _enderecoTipoService.Adicionar(enderecoTipo);
;
                return Ok(enderecoTipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("Delete")]
        public IActionResult Delete([FromBody]EnderecoTipoDto enderecoTipoDto)
        {
            BaseResponseDto baseResponseDTO = new BaseResponseDto();
            _requestInfoHelper.BindRequestInfo(HttpContext, baseResponseDTO);
            EnderecoTipo enderecoTipo = new EnderecoTipo();
            try
            {
                enderecoTipo.EnderecoTipoId = enderecoTipoDto.EnderecoTipoId;
                enderecoTipo.DescricaoTipo = enderecoTipoDto.DescricaoTipo;
                _enderecoTipoService.Deletar(enderecoTipo);
                baseResponseDTO.IsSuccess = true;
                baseResponseDTO.Response = JsonConvert.SerializeObject(enderecoTipo);
            }
            catch (Exception ex)
            {
                baseResponseDTO.IsSuccess = false;
                baseResponseDTO.Message = ex.Message;
            }
            return Ok(baseResponseDTO);
        }
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {

            EnderecoTipo enderecoTipo = new EnderecoTipo();
            enderecoTipo.EnderecoTipoId = Convert.ToInt32(id);
            try
            {
                enderecoTipo = _enderecoTipoService.GetById(enderecoTipo.EnderecoTipoId);
                return Ok(enderecoTipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("Update")]
        public IActionResult Update([FromBody] EnderecoTipoDto enderecoTipoDto)
        {
            EnderecoTipo enderecoTipo = new EnderecoTipo();
            try
            {
                enderecoTipo.EnderecoTipoId = enderecoTipoDto.EnderecoTipoId;
                enderecoTipo.DescricaoTipo = enderecoTipoDto.DescricaoTipo;
                _enderecoTipoService.Atualizar(enderecoTipo);
                return Ok(enderecoTipo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}