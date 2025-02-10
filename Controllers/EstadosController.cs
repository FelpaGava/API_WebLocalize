using API_Teste.Dto.Estados;
using API_Teste.Model;
using API_Teste.Services.Estados;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace API_Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly IEstadosInterface _estadosInterface; 

        public EstadosController(IEstadosInterface estadosInterface)
        {
            _estadosInterface = estadosInterface;
        }

        [HttpGet("ListarEstados")]
        public async Task<ActionResult<ResponseModel<List<EstadosModel>>>> ListarEstados()
        {
            var estados = await _estadosInterface.ListarEstados();
            return Ok(estados);
        }

        [HttpGet("BuscarEstadoPorId/{idEstados}")]
        public async Task<ActionResult<ResponseModel<EstadosModel>>> BuscarEstadoPorId(int idEstados)
        {
            var estados = await _estadosInterface.BuscarEstadoPorId(idEstados);
            return Ok(estados);
        }

        [HttpGet("BuscarEstadoPorLocal/{idLocal}")]
        public async Task<ActionResult<ResponseModel<EstadosModel>>> BuscarEstadoPorLocal(int idLocal)
        {
            var estados = await _estadosInterface.BuscarEstadoPorLocal(idLocal);
            return Ok(estados);
        }

        [HttpPost("CriarEstado")]
        public async Task<ActionResult<ResponseModel<List<EstadosModel>>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto)
        {
            var estados = await _estadosInterface.CriarEstado(estadoCriacaoDto);
            return Ok(estados);
        }

        [HttpPut("EditarEstado")]
        public async Task<ActionResult<ResponseModel<List<EstadosModel>>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto)
        {
            var estados = await _estadosInterface.EditarEstado(estadoEdicaoDto);
            return Ok(estados);
        }

        [HttpDelete("DeletarEstado/{idEstado}")]
        public async Task<ActionResult<ResponseModel<List<EstadosModel>>>> DeletarEstado(int idEstado)
        {
            var estados = await _estadosInterface.ExcluirEstado(idEstado);
            return Ok(estados);
        }

    }
}
