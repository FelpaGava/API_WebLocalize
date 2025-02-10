using API_Teste.Dto.Estados;
using API_Teste.Model;

namespace API_Teste.Services.Estados
{
    public interface IEstadosInterface
    {
        Task<ResponseModel<List<EstadosModel>>> ListarEstados(); 
        Task<ResponseModel<EstadosModel>> BuscarEstadoPorId(int idEstados); 
        Task<ResponseModel<EstadosModel>> BuscarEstadoPorLocal(int idLocal);
        Task<ResponseModel<List<EstadosModel>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto); 
        Task<ResponseModel<List<EstadosModel>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto); 
        Task<ResponseModel<List<EstadosModel>>> ExcluirEstado(int idEstado); 
    }
}
