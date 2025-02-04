using System.ComponentModel.DataAnnotations;
using API_Teste.Dto.Cidades.Vinculo;
using API_Teste.Dto.Locais.Vinculo;

namespace API_Teste.Dto.Locais
{
    public class LocaisCriacaoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public CidadeVinculo CidadeID { get; set; }
        public EstadoVinculo EstadoRelacao { get; set; }
    }
}
