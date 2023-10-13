﻿
using ApiPIM.Models;
using ApiPIM.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPIM.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionariosController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository= funcionarioRepository;
        }

        [HttpGet]
        public ActionResult GetListFuncionarios()
        {
            var funcionarios = _funcionarioRepository.Get();

            if(funcionarios == null)
            {
                return NotFound();
            }
            return Ok(funcionarios);
        }

        [HttpGet]
        [Route("dadosFuncionarioCompleto")]
        public async Task<ActionResult> RetornaDadosCompletos()
        {
            try
            {
                var infos = _funcionarioRepository.FuncionariosCompleto();

                if (infos == null)
                {
                    return NotFound("Nenhum dado encontrado.");
                }
                return Ok(infos);

            }
            catch (Exception ex)
            {

                return Problem("Ocorreu um erro ao retornar dados completos dos funcionários.", null, 500, "Erro retornar funcionários.", null);
                throw;
            }
        }

        [HttpPost]
        [Route("novoFuncionario")]
        public async Task<ActionResult> PostNovoFuncionario(FuncionarioDTO funcionarios)
        {
            try
            {
                bool f = await _funcionarioRepository.NovoFuncionario(funcionarios);

                if (f == false)
                {
                    return BadRequest("Houve um erro ao inserir o funcionario");
                }
                return Created("", f);
            }
            catch (Exception ex)
            {
                return Problem("Ocorreu um erro ao inserir funcionário.", null, 500, "Erro inserir funcionário.", null);
                throw;
            }
        }
        
    }
}
