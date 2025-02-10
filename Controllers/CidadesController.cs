using Microsoft.AspNetCore.Mvc;
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

        
        [HttpGet("ListarCidades")]
        public async Task<ActionResult<IEnumerable<CidadeDTO>>> GetCidades()
        {
            var resposta = await _cidadesService.ListarCidades();

            if (!resposta.Status)
            {
                return BadRequest(resposta.Mensagem);
            }

       
            var cidades = resposta.Dados.Select(c => new CidadeDTO
            {
                CidadeID = c.CidadeID,
                Nome = c.Nome,
                EstadoID = c.EstadoID,
                EstadoNome = c.EstadoRelacao?.Nome 
            }).ToList();

            return Ok(cidades);
        }

        [HttpGet("BuscarCidadePorNome/{nomeCidade}")]
        public async Task<IActionResult> BuscarCidadePorNome(string nomeCidade)
        {
            var resultado = await _cidadesService.BuscarCidadePorNome(nomeCidade);
            if (resultado.Status == false)
            {
                return NotFound(resultado.Mensagem);
            }
            return Ok(resultado);
        }


        [HttpGet("ListarCidadePorId{idCidade}")]
        public async Task<ActionResult<ResponseModel<CidadesModel>>> BuscarCidadePorId(int idCidade)
        {
            var resposta = await _cidadesService.BuscarCidadePorId(idCidade);
            if (!resposta.Status)
            {
                return NotFound(resposta); 
            }
            return Ok(resposta);
        }

        [HttpPost("CriarCidade")]
        public async Task<ActionResult<ResponseModel<List<CidadesModel>>>> CriarCidade([FromBody] CidadesCriacaoDto cidadeCriacaoDto)
        {
            var resposta = await _cidadesService.CriarCidade(cidadeCriacaoDto);
            if (!resposta.Status)
            {
                return BadRequest(resposta); 
            }
            return Ok(resposta);
        }

        
        [HttpPut("EditarCidade")]
        public async Task<ActionResult<ResponseModel<List<CidadesModel>>>> EditarCidade([FromBody] CidadesEdicaoDto cidadeEdicaoDto)
        {
            var resposta = await _cidadesService.EditarCidade(cidadeEdicaoDto);
            if (!resposta.Status)
            {
                return BadRequest(resposta); 
            }
            return Ok(resposta);
        }

   
        [HttpDelete("DeletarCidade{idCidade}")]
        public async Task<ActionResult<ResponseModel<List<CidadesModel>>>> ExcluirCidade(int idCidade)
        {
            var resposta = await _cidadesService.ExcluirCidade(idCidade);
            if (!resposta.Status)
            {
                return BadRequest(resposta); 
            }
            return Ok(resposta);
        }
    }
}