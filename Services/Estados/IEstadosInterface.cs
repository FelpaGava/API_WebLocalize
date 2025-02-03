using API_Teste.Dto.Estados;
using API_Teste.Model;

namespace API_Teste.Services.Estados
{
    public interface IEstadosInterface
    {
        Task<ResponseModel<List<EstadosModel>>> ListarEstados(); //listagem de Estados
        Task<ResponseModel<EstadosModel>> BuscarEstadoPorId(int idEstados); //busca de Estado por id
        Task<ResponseModel<EstadosModel>> BuscarEstadoPorLocal(int idLocal); //busca de Estado
        Task<ResponseModel<List<EstadosModel>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto); //criação de Estado
        Task<ResponseModel<List<EstadosModel>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto); //edição de Estado
        Task<ResponseModel<List<EstadosModel>>> ExcluirEstado(int idEstado); //deleção de Estado
    }
}
