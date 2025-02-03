using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Teste.Model
{
    //Propriedades da tabela Locais (Pontos Turísticos)
    public class LocaisModel
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(100)]
        public string Descricao { get; set; }

        [MaxLength(100)]
        public string Endereco { get; set; }

        [MaxLength(100)]
        public string Cidade { get; set; }
        public int EstadoID { get; set; } //chave estrangeira
    
        public EstadosModel EstadoRelacao { get; set; }

    }
}
