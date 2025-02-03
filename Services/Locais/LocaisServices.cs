using API_Teste.Data;
using API_Teste.Dto.Locais;
using API_Teste.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Teste.Services.local
{
    public class LocaisServices : ILocaisInterface
    {
        private readonly AppDbContext _context;

        public LocaisServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LocaisModel>>> ListarLocais()
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                var locais = await _context.Locais.Include(a => a.EstadoRelacao).ToListAsync();

                resposta.Dados = locais;
                resposta.Mensagem = "Pontos turísticos listados com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LocaisModel>> BuscarLocaisPorId(int idLocais)
        {
            ResponseModel<LocaisModel> resposta = new ResponseModel<LocaisModel>();
            try
            {
                var local = await _context.Locais.Include(a => a.EstadoRelacao)
                    .FirstOrDefaultAsync(locaisBanco => locaisBanco.Id == idLocais);

                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }
                resposta.Dados = local;
                resposta.Mensagem = "Ponto turístico encontrado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LocaisModel>>> BuscarLocaisPorIdEstado(int idEstados)
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();

            try
            {   //Buscar o estado do livro ("INCLUDE" é usado para incluir a entidade relacionada
                var locais = await _context.Locais
                    .Include(a => a.EstadoRelacao).Where(locaisBanco => locaisBanco.EstadoRelacao.EstadoID == idEstados)
                    .ToListAsync();

                if (locais == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                resposta.Dados = locais;
                resposta.Mensagem = "Pontos turísticos encontrados com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<LocaisModel>>> CriarLocais(LocaisCriacaoDto locaisCriacaoDto)
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();

            try
            {
                // Busca o estado pelo ID
                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.EstadoID == locaisCriacaoDto.EstadoRelacao.EstadoID);

                if (estado == null)
                {
                    resposta.Mensagem = "Estado não encontrado!";
                    return resposta;
                }

                // Criação do novo local
                var locais = new LocaisModel()
                {
                    Nome = locaisCriacaoDto.Nome,
                    Descricao = locaisCriacaoDto.Descricao,
                    Endereco = locaisCriacaoDto.Endereco,
                    Cidade = locaisCriacaoDto.Cidade,
                    EstadoRelacao = estado,
                };

               
                _context.Locais.Add(locais);
                await _context.SaveChangesAsync();

               
                resposta.Dados = await _context.Locais.Include(a => a.EstadoRelacao).ToListAsync();
                resposta.Mensagem = "Ponto turístico criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LocaisModel>>> EditarLocais(LocaisEdicaoDto locaisEdicaoDto)
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();

            try
            {
                // Busca o local pelo ID correto
                var local = await _context.Locais
                    .Include(a => a.EstadoRelacao)
                    .FirstOrDefaultAsync(locaisBanco => locaisBanco.Id == locaisEdicaoDto.Id);
                
               // Busca o estado correto
                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.EstadoID == locaisEdicaoDto.EstadoID.EstadoID);


                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro de Ponto turístico encontrado!";
                    return resposta;
                }

                if (estado == null)
                {
                    resposta.Mensagem = "Nenhum registro neste estado localizado!";
                    return resposta;
                }

                // Atualiza os campos do local
                local.Nome = locaisEdicaoDto.Nome;
                local.Descricao = locaisEdicaoDto.Descricao;
                local.Endereco = locaisEdicaoDto.Endereco;
                local.Cidade = locaisEdicaoDto.Cidade;
                local.EstadoID = estado.EstadoID; 
                local.EstadoRelacao = estado;

                
                _context.Locais.Update(local);
                await _context.SaveChangesAsync();

                
                resposta.Dados = await _context.Locais.Include(a => a.EstadoRelacao).ToListAsync();
                resposta.Mensagem = "Ponto turístico editado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LocaisModel>>> ExcluirLocais(int idLocais)
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();

            try
            {
                var locais = await _context.Locais
                    .Include(a => a.EstadoRelacao)
                    .FirstOrDefaultAsync(locaisBanco => locaisBanco.Id == idLocais);

                if (locais == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                _context.Remove(locais);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Locais.ToListAsync();
                resposta.Mensagem = "Ponto turístico excluído com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LocaisModel>>> BuscarPorNomeOuDescricao(string termo)
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();

            try
            {
                if (string.IsNullOrWhiteSpace(termo))
                {
                    resposta.Mensagem = "O termo de busca não pode ser vazio.";
                    return resposta;
                }

                var locais = await _context.Locais
                    .Where(p => EF.Functions.Like(p.Nome, $"%{termo}%") ||
                                EF.Functions.Like(p.Descricao, $"%{termo}%"))
                    .ToListAsync();

                if (locais == null || !locais.Any())
                {
                    resposta.Mensagem = "Nenhum ponto turístico encontrado com esse termo.";
                    return resposta;
                }

                resposta.Dados = locais;
                resposta.Mensagem = "Pontos turísticos encontrados com sucesso!";
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
