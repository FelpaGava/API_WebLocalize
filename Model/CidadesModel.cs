using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Teste.Model
{
    public class CidadesModel
    {
        [Key] 
        public int CidadeID { get; set; }
        public string Nome { get; set; }

        public int EstadoID { get; set; }
        [JsonIgnore]
        public EstadosModel EstadoRelacao { get; set; }
    }
}
