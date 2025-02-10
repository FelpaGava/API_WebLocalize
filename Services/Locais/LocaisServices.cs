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

        public async Task<ResponseModel<List<LocaisModel>>> ListarLocais()
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                var locais = await _context.Locais
                    .Include(l => l.EstadoRelacao) 
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

        
        public async Task<ResponseModel<LocaisModel>> BuscarLocaisPorId(int idLocais)
        {
            var resposta = new ResponseModel<LocaisModel>();
            try
            {
                var local = await _context.Locais
                    .Include(l => l.EstadoRelacao) 
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

        
        public async Task<ResponseModel<List<LocaisModel>>> BuscarLocaisPorIdCidade(int idCidade)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
                var locais = await _context.Locais
                    .Include(l => l.EstadoRelacao) 
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

        
        public async Task<ResponseModel<List<LocaisModel>>> CriarLocais(LocaisCriacaoDto locaisCriacaoDto)
        {
            ResponseModel<List<LocaisModel>> resposta = new ResponseModel<List<LocaisModel>>();

            try
            {
                // Verificar se a cidade existe no banco
                var cidade = await _context.Cidades.FindAsync(locaisCriacaoDto.CidadeID);
                if (cidade == null)
                {
                    resposta.Mensagem = "Cidade não encontrada.";
                    resposta.Status = false;
                    return resposta;
                }

                // Verificar se o estado existe no banco
                var estado = await _context.Estados.FindAsync(locaisCriacaoDto.EstadoRelacao.EstadoID);
                if (estado == null)
                {
                    resposta.Mensagem = "Estado não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                var local = new LocaisModel
                {
                    Nome = locaisCriacaoDto.Nome,
                    Descricao = locaisCriacaoDto.Descricao,
                    Endereco = locaisCriacaoDto.Endereco,
                    CidadeID = locaisCriacaoDto.CidadeID,
                    EstadoID = locaisCriacaoDto.EstadoRelacao.EstadoID
                };

                _context.Add(local);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Locais.ToListAsync();
                resposta.Mensagem = "Local criado com sucesso";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao criar local: {ex.Message}. {ex.InnerException?.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

       
      public async Task<ResponseModel<List<LocaisModel>>> EditarLocais(LocaisEdicaoDto locaisEdicaoDto)
{
    var resposta = new ResponseModel<List<LocaisModel>>();
    try
    {
        // Busca o local pelo ID
        var local = await _context.Locais
            .Include(l => l.CidadeRelacao)
            .FirstOrDefaultAsync(l => l.Id == locaisEdicaoDto.Id);

        if (local == null)
        {
            resposta.Mensagem = "Nenhum registro de ponto turístico encontrado!";
            resposta.Status = false;
            return resposta;
        }

        // Verifica se a nova cidade existe
        var cidade = await _context.Cidades
            .FirstOrDefaultAsync(c => c.CidadeID == locaisEdicaoDto.CidadeID.CidadeID); // 🔹 Correção aqui

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
        local.CidadeID = locaisEdicaoDto.CidadeID.CidadeID; // 🔹 Correção aqui

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


       
        public async Task<ResponseModel<List<LocaisModel>>> ExcluirLocais(int idLocais)
        {
            var resposta = new ResponseModel<List<LocaisModel>>();
            try
            {
               
                var local = await _context.Locais
                    .FirstOrDefaultAsync(l => l.Id == idLocais);

                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

               
                _context.Locais.Remove(local);
                await _context.SaveChangesAsync();

                
                resposta.Dados = await _context.Locais
                    .Include(l => l.CidadeRelacao) 
                    .ThenInclude(c => c.EstadoRelacao) 
                    .AsNoTracking()
                    .ToListAsync();

                resposta.Mensagem = "Ponto turístico excluído com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao excluir local: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }


        
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

               
                var locais = await _context.Locais
                    .Include(l => l.CidadeRelacao) 
                    .Where(l => EF.Functions.Like(l.Nome, $"%{termo}%") ||
                                EF.Functions.Like(l.Descricao, $"%{termo}%") ||
                                (l.CidadeRelacao != null && EF.Functions.Like(l.CidadeRelacao.Nome, $"%{termo}%")))
                    .ToListAsync();

                if (locais == null || !locais.Any())
                {
                    resposta.Mensagem = "Nenhum ponto turístico encontrado com esse termo.";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = locais;
                resposta.Mensagem = "Pontos turísticos encontrados com sucesso!";
                resposta.Status = true; 
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao buscar locais: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
