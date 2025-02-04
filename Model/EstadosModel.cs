using System.Text.Json.Serialization;

namespace API_Teste.Model
{
    // Propriedades da tabela Estados
    public class EstadosModel
    {
        public int EstadoID { get; set; }
        public string Nome { get; set; } 
        public string Sigla { get; set; }

        public ICollection<CidadesModel> Cidades { get; set; }

    }
}
