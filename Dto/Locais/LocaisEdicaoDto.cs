﻿using API_Teste.Dto.Locais.Vinculo;

namespace API_Teste.Dto.Locais
{
    public class LocaisEdicaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public EstadoVinculo EstadoID { get; set; }
    }
}
