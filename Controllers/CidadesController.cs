﻿using Microsoft.AspNetCore.Mvc;
using API_Teste.Services.Cidades;
using API_Teste.Dto.Cidades;
using API_Teste.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadesController : ControllerBase
    {
        private readonly ICidadesInterface _cidadesService;

        public CidadesController(ICidadesInterface cidadesService)
        {
            _cidadesService = cidadesService;
        }

        // Endpoint para listar todas as cidades
        [HttpGet("ListarCidades")]
        public async Task<ActionResult<IEnumerable<CidadeDTO>>> GetCidades()
        {
            var resposta = await _cidadesService.ListarCidades();

            // Verifica se a resposta foi bem-sucedida
            if (!resposta.Status)
            {
                return BadRequest(resposta.Mensagem);
            }

            // Mapeia para DTO
            var cidades = resposta.Dados.Select(c => new CidadeDTO
            {
                CidadeID = c.CidadeID,
                Nome = c.Nome,
                EstadoID = c.EstadoID,
                EstadoNome = c.EstadoRelacao?.Nome // Verifica se EstadoRelacao não é nulo
            }).ToList();

            return Ok(cidades);
        }

        // Endpoint para buscar uma cidade por ID
        [HttpGet("ListarCidadePorId{idCidade}")]
        public async Task<ActionResult<ResponseModel<CidadesModel>>> BuscarCidadePorId(int idCidade)
        {
            var resposta = await _cidadesService.BuscarCidadePorId(idCidade);
            if (!resposta.Status)
            {
                return NotFound(resposta); // Retorna 404 se a cidade não for encontrada
            }
            return Ok(resposta);
        }

        // Endpoint para criar uma nova cidade
        [HttpPost("CriarCidade")]
        public async Task<ActionResult<ResponseModel<List<CidadesModel>>>> CriarCidade([FromBody] CidadesCriacaoDto cidadeCriacaoDto)
        {
            var resposta = await _cidadesService.CriarCidade(cidadeCriacaoDto);
            if (!resposta.Status)
            {
                return BadRequest(resposta); // Retorna 400 em caso de erro
            }
            return Ok(resposta);
        }

        // Endpoint para editar uma cidade existente
        [HttpPut("EditarCidade")]
        public async Task<ActionResult<ResponseModel<List<CidadesModel>>>> EditarCidade([FromBody] CidadesEdicaoDto cidadeEdicaoDto)
        {
            var resposta = await _cidadesService.EditarCidade(cidadeEdicaoDto);
            if (!resposta.Status)
            {
                return BadRequest(resposta); // Retorna 400 em caso de erro
            }
            return Ok(resposta);
        }

        // Endpoint para excluir uma cidade
        [HttpDelete("DeletarCidade{idCidade}")]
        public async Task<ActionResult<ResponseModel<List<CidadesModel>>>> ExcluirCidade(int idCidade)
        {
            var resposta = await _cidadesService.ExcluirCidade(idCidade);
            if (!resposta.Status)
            {
                return BadRequest(resposta); // Retorna 400 em caso de erro
            }
            return Ok(resposta);
        }
    }
}