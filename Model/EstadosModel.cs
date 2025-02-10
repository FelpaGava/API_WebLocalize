using System.Text.Json.Serialization;

namespace API_Teste.Model
{
    public class EstadosModel
    {
        public int EstadoID { get; set; }
        public string Nome { get; set; } 
        public string Sigla { get; set; }

        public ICollection<CidadesModel> Cidades { get; set; } = new List<CidadesModel>(); 

    }
}
