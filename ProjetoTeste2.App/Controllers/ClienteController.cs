using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoTeste2.Domains.Dtos;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Service;
using ProjetoTeste2.Domains.Utils;

namespace ProjetoTeste2.App.Controllers
{
    [Produces("application/json")]
    [Route("ClienteAPI")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IMapper mapper, IClienteService clienteService)
        {
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [Route("GetAll")]
        public IActionResult GetAll()
        {

            try
            {

                IEnumerable<Cliente> clientes = _clienteService.GetAll().ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Create")]
        public IActionResult Create([FromBody] ClienteDto clienteDto)
        {

            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _clienteService.Add(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {

            try
            {
                id = Utilities.FormatarCNPJ(id);
                Cliente cliente = _clienteService.GetById(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("Update")]
        public IActionResult Update([FromBody] ClienteDto clienteDto)
        {

            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _clienteService.Upd(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete")]
        public IActionResult Delete([FromBody] ClienteDto clienteDto)
        {

            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _clienteService.Del(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}