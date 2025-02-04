using API_Teste.Dto.Locais;
using API_Teste.Model;

namespace API_Teste.Services.Local
{
    public interface ILocaisInterface
    {
        Task<ResponseModel<List<LocaisModel>>> ListarLocais();
        Task<ResponseModel<LocaisModel>> BuscarLocaisPorId(int idLocais);
        Task<ResponseModel<List<LocaisModel>>> BuscarLocaisPorIdCidade(int idCidade);
        Task<ResponseModel<List<LocaisModel>>> CriarLocais(LocaisCriacaoDto locaisCriacaoDto);
        Task<ResponseModel<List<LocaisModel>>> EditarLocais(LocaisEdicaoDto locaisEdicaoDto);
        Task<ResponseModel<List<LocaisModel>>> ExcluirLocais(int idLocais);
        Task<ResponseModel<List<LocaisModel>>> BuscarPorNomeOuDescricao(string termo);
    }
}