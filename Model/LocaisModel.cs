using API_Teste.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class LocaisModel
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Nome { get; set; }

    [MaxLength(100)]
    public string Descricao { get; set; }

    [MaxLength(100)]
    public string Endereco { get; set; }

    [Required]
    public int CidadeID { get; set; }  

    [JsonIgnore]
    public CidadesModel CidadeRelacao { get; set; } 

    [Required] 
    public int EstadoID { get; set; } 

    [JsonIgnore]
    public EstadosModel EstadoRelacao { get; set; } 
}
