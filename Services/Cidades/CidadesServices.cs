using API_Teste.Data;
using API_Teste.Dto.Cidades; // Você precisará criar DTOs para Cidades
using API_Teste.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Teste.Services.Cidades
{
    public class CidadesServices : ICidadesInterface
    {
        private readonly AppDbContext _context;

        public CidadesServices(AppDbContext context)
        {
            _context = context;
        }

        // Listar todas as cidades
        public async Task<ResponseModel<List<CidadesModel>>> ListarCidades()
        {
            var cidades = await _context.Cidades
                .Include(c => c.EstadoRelacao) // 🔹 Inclui o estado na consulta
                .ToListAsync();

            return new ResponseModel<List<CidadesModel>>
            {
                Status = true,
                Dados = cidades,
                Mensagem = "Cidades listadas com sucesso"
            };
        }


        // Buscar cidade por ID
        public async Task<ResponseModel<CidadesModel>> BuscarCidadePorId(int idCidade)
        {
            ResponseModel<CidadesModel> resposta = new ResponseModel<CidadesModel>();
            try
            {
                var cidade = await _context.Cidades
                    .Include(c => c.EstadoRelacao) // Inclui o estado relacionado
                    .FirstOrDefaultAsync(c => c.CidadeID == idCidade);

                if (cidade == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                resposta.Dados = cidade;
                resposta.Mensagem = "Cidade encontrada com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // Criar uma nova cidade
        public async Task<ResponseModel<List<CidadesModel>>> CriarCidade(CidadesCriacaoDto cidadeCriacaoDto)
        {
            ResponseModel<List<CidadesModel>> resposta = new ResponseModel<List<CidadesModel>>();

            try
            {
                // Verificar se o estado existe
                var estado = await _context.Estados.FindAsync(cidadeCriacaoDto.EstadoID);
                
                if (estado == null)
                {
                    resposta.Mensagem = "Estado não encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

                // Criar a cidade e associá-la ao estado
                var cidade = new CidadesModel
                {
                    Nome = cidadeCriacaoDto.Nome,
                    EstadoID = cidadeCriacaoDto.EstadoID
                };

                estado.Cidades.Add(cidade); // Adiciona a cidade ao estado
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cidades.ToListAsync(); // Retornar a lista de cidades
                resposta.Mensagem = "Cidade criada com sucesso";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.InnerException?.Message ?? ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        // Editar uma cidade existente
        public async Task<ResponseModel<List<CidadesModel>>> EditarCidade(CidadesEdicaoDto cidadeEdicaoDto)
        {
            ResponseModel<List<CidadesModel>> resposta = new ResponseModel<List<CidadesModel>>();
            try
            {
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.CidadeID == cidadeEdicaoDto.Id);

                if (cidade == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                cidade.Nome = cidadeEdicaoDto.Nome;
                cidade.EstadoID = cidadeEdicaoDto.EstadoID;

                _context.Update(cidade);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cidades.ToListAsync();
                resposta.Mensagem = "Cidade editada com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // Excluir uma cidade
        public async Task<ResponseModel<List<CidadesModel>>> ExcluirCidade(int idCidade)
        {
            ResponseModel<List<CidadesModel>> resposta = new ResponseModel<List<CidadesModel>>();
            try
            {
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.CidadeID == idCidade);

                if (cidade == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                _context.Remove(cidade);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Cidades.ToListAsync();
                resposta.Mensagem = "Cidade excluída com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}