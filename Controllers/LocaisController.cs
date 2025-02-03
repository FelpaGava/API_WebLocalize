using API_Teste.Dto.Locais;
using API_Teste.Services.local;
using Microsoft.AspNetCore.Mvc;

namespace API_Teste.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]

    public class LocaisController : ControllerBase
    {
        private readonly ILocaisInterface _locaisInterface; //Injeção de dependência
        public LocaisController(ILocaisInterface locaisInterface)
        {
            _locaisInterface = locaisInterface;
        }

        [HttpGet("ListarLocais")]
        public async Task<IActionResult> ListarLocais()
        {
            var resposta = await _locaisInterface.ListarLocais();
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }

        [HttpGet("BuscarLocaisPorId")]
        public async Task<IActionResult> BuscarLocaisPorId(int idLocais)
        {
            var resposta = await _locaisInterface.BuscarLocaisPorId(idLocais);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }

        [HttpGet("BuscarLocaisPorIdEstado")]
        public async Task<IActionResult> BuscarLocaisPorIdEstado(int idEstados)
        {
            var resposta = await _locaisInterface.BuscarLocaisPorIdEstado(idEstados);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }

        [HttpPost("CriarLocais")]
        public async Task<IActionResult> CriarLocais(LocaisCriacaoDto locaisCriacaoDto)
        {
            var resposta = await _locaisInterface.CriarLocais(locaisCriacaoDto);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }

        [HttpPut("EditarLocais")]
        public async Task<IActionResult> EditarLocais(LocaisEdicaoDto locaisEdicaoDto)
        {
            var resposta = await _locaisInterface.EditarLocais(locaisEdicaoDto);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }

        [HttpDelete("ExcluirLocais")]
        public async Task<IActionResult> ExcluirLocais(int idLocais)
        {
            var resposta = await _locaisInterface.ExcluirLocais(idLocais);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }

        [HttpGet("BuscarPorNomeOuDescricao")]
        public async Task<IActionResult> BuscarPorNomeOuDescricao(string termo)
        {
            var resposta = await _locaisInterface.BuscarPorNomeOuDescricao(termo);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            return BadRequest(resposta);
        }
    }
}
