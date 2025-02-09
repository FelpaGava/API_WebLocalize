using API_Teste.Dto.Cidades;
using API_Teste.Model;

namespace API_Teste.Services.Cidades
{
    public interface ICidadesInterface
    {
        Task<ResponseModel<List<CidadesModel>>> ListarCidades();
        Task<ResponseModel<CidadesModel>> BuscarCidadePorId(int idCidade);
        Task<ResponseModel<List<CidadesModel>>> CriarCidade(CidadesCriacaoDto cidadeCriacaoDto);
        Task<ResponseModel<List<CidadesModel>>> EditarCidade(CidadesEdicaoDto cidadeEdicaoDto);
        Task<ResponseModel<List<CidadesModel>>> ExcluirCidade(int idCidade);
        Task<ResponseModel<CidadesModel>> BuscarCidadePorNome(string nomeCidade);
    }
}
