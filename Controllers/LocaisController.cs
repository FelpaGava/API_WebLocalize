using Microsoft.AspNetCore.Mvc;
using API_Teste.Services.Local;
using API_Teste.Dto.Locais;
using API_Teste.Model;

namespace API_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        private readonly ILocaisInterface _locaisService;

        public LocaisController(ILocaisInterface locaisService)
        {
            _locaisService = locaisService;
        }

        [HttpGet("ListarLocais")]
        public async Task<ActionResult<ResponseModel<List<LocaisModel>>>> ListarLocais()
        {
            var resposta = await _locaisService.ListarLocais();
            return Ok(resposta);
        }

        [HttpGet("BuscarLocalPorId/{idLocais}")]
        public async Task<ActionResult<ResponseModel<LocaisModel>>> BuscarLocaisPorId(int idLocais)
        {
            var resposta = await _locaisService.BuscarLocaisPorId(idLocais);
            if (!resposta.Status)
            {
                return NotFound(resposta);
            }
            return Ok(resposta);
        }

        [HttpPost("CriarLocal")]
        public async Task<ActionResult<ResponseModel<List<LocaisModel>>>> CriarLocais([FromBody] LocaisCriacaoDto locaisCriacaoDto)
        {
            var resposta = await _locaisService.CriarLocais(locaisCriacaoDto);
            if (!resposta.Status)
            {
                return BadRequest(resposta);
            }
            return Ok(resposta);
        }

        [HttpPut("EditarLocal")]
        public async Task<ActionResult<ResponseModel<List<LocaisModel>>>> EditarLocais([FromBody] LocaisEdicaoDto locaisEdicaoDto)
        {
            var resposta = await _locaisService.EditarLocais(locaisEdicaoDto);
            if (!resposta.Status)
            {
                return BadRequest(resposta);
            }
            return Ok(resposta);
        }

        [HttpDelete("DeletarLocal{idLocais}")]
        public async Task<ActionResult<ResponseModel<List<LocaisModel>>>> ExcluirLocais(int idLocais)
        {
            var resposta = await _locaisService.ExcluirLocais(idLocais);
            if (!resposta.Status)
            {
                return BadRequest(resposta);
            }
            return Ok(resposta);
        }

        [HttpGet("BuscarPorTermo")]
        public async Task<ActionResult<ResponseModel<List<LocaisModel>>>> BuscarPorNomeOuDescricao([FromQuery] string termo)
        {
            var resposta = await _locaisService.BuscarPorNomeOuDescricao(termo);
            if (!resposta.Status)
            {
                return NotFound(resposta);
            }
            return Ok(resposta);
        }
    }
}