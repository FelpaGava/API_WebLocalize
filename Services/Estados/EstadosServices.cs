using API_Teste.Data;
using API_Teste.Dto.Estados;
using API_Teste.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Teste.Services.Estados
{
    public class EstadosServices : IEstadosInterface
    {
        private readonly AppDbContext _context;

        public EstadosServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<EstadosModel>>> ListarEstados()
        {
            ResponseModel<List<EstadosModel>> resposta = new ResponseModel<List<EstadosModel>>();
            try
            {
                var estados = await _context.Estados.ToListAsync();

                resposta.Dados = estados;
                resposta.Mensagem = "Estados listados com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<EstadosModel>> BuscarEstadoPorLocal(int idLocal)
        {
            ResponseModel<EstadosModel> resposta = new ResponseModel<EstadosModel>();

            try
            {
                var local = await _context.Locais
                    .Include(e => e.EstadoRelacao)
                    .FirstOrDefaultAsync(EstadoBanco => EstadoBanco.Id == idLocal);

                if (local == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                resposta.Dados = local.EstadoRelacao;
                resposta.Mensagem = "Estado encontrado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


        public async Task<ResponseModel<EstadosModel>> BuscarEstadoPorId(int idEstados)
        {
            ResponseModel<EstadosModel> resposta = new ResponseModel<EstadosModel>();
            try
            {
               
                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.EstadoID == idEstados);

                if (estado == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }
                resposta.Dados = estado;
                resposta.Mensagem = "Autor encontrado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<EstadosModel>>> CriarEstado(EstadoCriacaoDto estadoCriacaoDto)
        {
            ResponseModel<List<EstadosModel>> resposta = new ResponseModel<List<EstadosModel>>();

            try
            {
                var estados = new EstadosModel
                {
                    Nome = estadoCriacaoDto.Nome,
                    Sigla = estadoCriacaoDto.Sigla,
                };

                _context.Add(estados);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estados.ToListAsync();
                resposta.Mensagem = "Estado criado com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<EstadosModel>>> EditarEstado(EstadoEdicaoDto estadoEdicaoDto)
        {
            ResponseModel<List<EstadosModel>> resposta = new ResponseModel<List<EstadosModel>>();

            try
            {
                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.EstadoID == estadoEdicaoDto.EstadoID);

                if (estado == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                estado.Nome = estadoEdicaoDto.Nome;
                estado.Sigla = estadoEdicaoDto.Sigla;

                _context.Update(estado);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estados.ToListAsync();
                resposta.Mensagem = "Estado editado com sucesso";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<EstadosModel>>> ExcluirEstado(int idEstados)
        {
            ResponseModel<List<EstadosModel>> resposta = new ResponseModel<List<EstadosModel>>();

            try
            {
                var estado = await _context.Estados
                    .FirstOrDefaultAsync(estadoBanco => estadoBanco.EstadoID == idEstados);

                if (estado == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado!";
                    return resposta;
                }

                _context.Remove(estado);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Estados.ToListAsync();
                resposta.Mensagem = "Estado excluído com sucesso";

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
