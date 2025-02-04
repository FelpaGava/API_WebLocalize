using API_Teste.Data;
using API_Teste.Dto.Locais;
using API_Teste.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Teste.Services.Local
{
    public class LocaisServices : ILocaisInterface
    {
        private readonly AppDbContext _context;

        public LocaisServices(AppDbContext context)
        {
            _context = context;
        }

        // Listar todos os locais
        public async Task<ResponseModel<List<LocaisModel>>> ListarLocais()
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                var locais = await _context.Locais
                    .Include(l => l.EstadoRelacao) // Inclui a cidade relacionada
                    .ToListAsync();

                resposta.Dados = locais;
                resposta.Mensagem = "Pontos turísticos listados com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // Buscar local por ID
        public async Task<ResponseModel<LocaisModel>> BuscarLocaisPorId(int idLocais)
        {
            var resposta = new ResponseModel<LocaisModel>();
            try
            {
                var local = await _context.Locais
                    .Include(l => l.EstadoRelacao) // Inclui a cidade relacionada
                    .FirstOrDefaultAsync(l => l.Id == idLocais);

                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                resposta.Dados = local;
                resposta.Mensagem = "Ponto turístico encontrado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // Buscar locais por ID da cidade
        public async Task<ResponseModel<List<LocaisModel>>> BuscarLocaisPorIdCidade(int idCidade)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                var locais = await _context.Locais
                    .Include(l => l.EstadoRelacao) // Inclui a cidade relacionada
                    .Where(l => l.CidadeID == idCidade)
                    .ToListAsync();

                if (locais == null || !locais.Any())
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
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

        // Criar um novo local
        public async Task<ResponseModel<List<LocaisModel>>> CriarLocais(LocaisCriacaoDto locaisCriacaoDto)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                // Verifica se a cidade existe usando o ID fornecido no CidadeVinculo
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.CidadeID == locaisCriacaoDto.CidadeID.CidadeID);  // Acessa o ID da cidade dentro do objeto CidadeVinculo

                if (cidade == null)
                {
                    resposta.Mensagem = "Cidade não encontrada!";
                    resposta.Status = false;
                    return resposta;
                }

                // Cria o novo local
                var local = new LocaisModel()
                {
                    Nome = locaisCriacaoDto.Nome,
                    Descricao = locaisCriacaoDto.Descricao,
                    Endereco = locaisCriacaoDto.Endereco,
                    CidadeID = locaisCriacaoDto.CidadeID.CidadeID,  // Atribui o ID da cidade
                    EstadoID = cidade.EstadoID,  // Atribui o estado da cidade
                };

                // Adiciona o local ao banco de dados
                _context.Locais.Add(local);
                await _context.SaveChangesAsync();

                // Retorna a lista atualizada de locais
                resposta.Dados = await _context.Locais
                    .Include(l => l.CidadeRelacao)  // Inclui a cidade relacionada
                    .Include(l => l.EstadoRelacao)  // Inclui o estado relacionado
                    .ToListAsync();

                resposta.Mensagem = "Ponto turístico criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao criar local: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

        // Editar um local existente
        public async Task<ResponseModel<List<LocaisModel>>> EditarLocais(LocaisEdicaoDto locaisEdicaoDto)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                // Busca o local pelo ID
                var local = await _context.Locais
                    .Include(l => l.CidadeID)
                    .FirstOrDefaultAsync(l => l.Id == locaisEdicaoDto.Id);

                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro de ponto turístico encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

                // Verifica se a nova cidade existe
                var cidade = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.CidadeID == locaisEdicaoDto.Id);

                if (cidade == null)
                {
                    resposta.Mensagem = "Cidade não encontrada!";
                    resposta.Status = false;
                    return resposta;
                }

                // Atualiza os campos do local
                local.Nome = locaisEdicaoDto.Nome;
                local.Descricao = locaisEdicaoDto.Descricao;
                local.Endereco = locaisEdicaoDto.Endereco;
                local.CidadeID = locaisEdicaoDto.Id; // Atualiza o ID da cidade

                // Salva as alterações no banco de dados
                _context.Locais.Update(local);
                await _context.SaveChangesAsync();

                // Retorna a lista atualizada de locais
                resposta.Dados = await _context.Locais
                    .Include(l => l.EstadoRelacao)
                    .ToListAsync();
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

        // Excluir um local
        public async Task<ResponseModel<List<LocaisModel>>> ExcluirLocais(int idLocais)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                // Busca o local pelo ID
                var local = await _context.Locais
                    .FirstOrDefaultAsync(l => l.Id == idLocais);

                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

                // Remove o local do banco de dados
                _context.Locais.Remove(local);
                await _context.SaveChangesAsync();

                // Retorna a lista atualizada de locais
                resposta.Dados = await _context.Locais
                    .Include(l => l.Id)
                    .ToListAsync();
                resposta.Mensagem = "Ponto turístico excluído com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        // Buscar locais por nome ou descrição
        public async Task<ResponseModel<List<LocaisModel>>> BuscarPorNomeOuDescricao(string termo)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                if (string.IsNullOrWhiteSpace(termo))
                {
                    resposta.Mensagem = "O termo de busca não pode ser vazio.";
                    resposta.Status = false;
                    return resposta;
                }

                // Busca locais que contenham o termo no nome ou na descrição
                var locais = await _context.Locais
                    .Where(l => EF.Functions.Like(l.Nome, $"%{termo}%") ||
                                EF.Functions.Like(l.Descricao, $"%{termo}%"))
                    .ToListAsync();

                if (locais == null || !locais.Any())
                {
                    resposta.Mensagem = "Nenhum ponto turístico encontrado com esse termo.";
                    resposta.Status = false;
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