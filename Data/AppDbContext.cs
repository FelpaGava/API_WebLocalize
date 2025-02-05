using API_Teste.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Teste.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<EstadosModel> Estados { get; set; }
        public DbSet<LocaisModel> Locais { get; set; }
        public DbSet<CidadesModel> Cidades { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EstadosModel>()
                .HasKey(e => e.EstadoID);

            // Inserção dos dados da tabela Estados
            modelBuilder.Entity<EstadosModel>().HasData(
                new EstadosModel { EstadoID = 1, Nome = "Acre", Sigla = "AC" },
                new EstadosModel { EstadoID = 2, Nome = "Alagoas", Sigla = "AL" },
                new EstadosModel { EstadoID = 3, Nome = "Amapá", Sigla = "AP" },
                new EstadosModel { EstadoID = 4, Nome = "Amazonas", Sigla = "AM" },
                new EstadosModel { EstadoID = 5, Nome = "Bahia", Sigla = "BA" },
                new EstadosModel { EstadoID = 6, Nome = "Ceará", Sigla = "CE" },
                new EstadosModel { EstadoID = 7, Nome = "Distrito Federal", Sigla = "DF" },
                new EstadosModel { EstadoID = 8, Nome = "Espírito Santo", Sigla = "ES" },
                new EstadosModel { EstadoID = 9, Nome = "Goiás", Sigla = "GO" },
                new EstadosModel { EstadoID = 10, Nome = "Maranhão", Sigla = "MA" },
                new EstadosModel { EstadoID = 11, Nome = "Mato Grosso", Sigla = "MT" },
                new EstadosModel { EstadoID = 12, Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new EstadosModel { EstadoID = 13, Nome = "Minas Gerais", Sigla = "MG" },
                new EstadosModel { EstadoID = 14, Nome = "Pará", Sigla = "PA" },
                new EstadosModel { EstadoID = 15, Nome = "Paraíba", Sigla = "PB" },
                new EstadosModel { EstadoID = 16, Nome = "Paraná", Sigla = "PR" },
                new EstadosModel { EstadoID = 17, Nome = "Pernambuco", Sigla = "PE" },
                new EstadosModel { EstadoID = 18, Nome = "Piauí", Sigla = "PI" },
                new EstadosModel { EstadoID = 19, Nome = "Rio de Janeiro", Sigla = "RJ" },
                new EstadosModel { EstadoID = 20, Nome = "Rio Grande do Norte", Sigla = "RN" },
                new EstadosModel { EstadoID = 21, Nome = "Rio Grande do Sul", Sigla = "RS" },
                new EstadosModel { EstadoID = 22, Nome = "Rondônia", Sigla = "RO" },
                new EstadosModel { EstadoID = 23, Nome = "Roraima", Sigla = "RR" },
                new EstadosModel { EstadoID = 24, Nome = "Santa Catarina", Sigla = "SC" },
                new EstadosModel { EstadoID = 25, Nome = "São Paulo", Sigla = "SP" },
                new EstadosModel { EstadoID = 26, Nome = "Sergipe", Sigla = "SE" },
                new EstadosModel { EstadoID = 27, Nome = "Tocantins", Sigla = "TO" }
            );

            // Inserção de cidades
            modelBuilder.Entity<CidadesModel>().HasData(
                new CidadesModel { CidadeID = 1, Nome = "Tupã", EstadoID = 25 },
                new CidadesModel { CidadeID = 2, Nome = "Marília", EstadoID = 25 },
                new CidadesModel { CidadeID = 3, Nome = "Vera Cruz", EstadoID = 25 },
                new CidadesModel { CidadeID = 4, Nome = "Pompeia", EstadoID = 25 },
                new CidadesModel { CidadeID = 5, Nome = "Ocauçu", EstadoID = 25 },
                new CidadesModel { CidadeID = 6, Nome = "Júlio Mesquita", EstadoID = 25 },
                new CidadesModel { CidadeID = 7, Nome = "Lupércio", EstadoID = 25 },
                new CidadesModel { CidadeID = 8, Nome = "Alvinlândia", EstadoID = 25 },
                new CidadesModel { CidadeID = 9, Nome = "Guaimbê", EstadoID = 25 },
                new CidadesModel { CidadeID = 10, Nome = "Echaporã", EstadoID = 25 },
                new CidadesModel { CidadeID = 11, Nome = "Oscar Bressane", EstadoID = 25 },
                new CidadesModel { CidadeID = 12, Nome = "Queiroz", EstadoID = 25 },
                new CidadesModel { CidadeID = 13, Nome = "Borá", EstadoID = 25 },
                new CidadesModel { CidadeID = 14, Nome = "Cândido Mota", EstadoID = 25 },
                new CidadesModel { CidadeID = 15, Nome = "Paraguaçu Paulista", EstadoID = 25 },

                // Bahia (BA)
                new CidadesModel { CidadeID = 16, Nome = "Salvador", EstadoID = 5 },
                new CidadesModel { CidadeID = 17, Nome = "Feira de Santana", EstadoID = 5 },
                new CidadesModel { CidadeID = 18, Nome = "Vitória da Conquista", EstadoID = 5 },
                new CidadesModel { CidadeID = 19, Nome = "Camaçari", EstadoID = 5 },
                new CidadesModel { CidadeID = 20, Nome = "Itabuna", EstadoID = 5 },

                // Minas Gerais (MG)
                new CidadesModel { CidadeID = 21, Nome = "Belo Horizonte", EstadoID = 13 },
                new CidadesModel { CidadeID = 22, Nome = "Uberlândia", EstadoID = 13 },
                new CidadesModel { CidadeID = 23, Nome = "Contagem", EstadoID = 13 },
                new CidadesModel { CidadeID = 24, Nome = "Juiz de Fora", EstadoID = 13 },
                new CidadesModel { CidadeID = 25, Nome = "Betim", EstadoID = 13 },

                // Paraná (PR)
                new CidadesModel { CidadeID = 26, Nome = "Curitiba", EstadoID = 16 },
                new CidadesModel { CidadeID = 27, Nome = "Londrina", EstadoID = 16 },
                new CidadesModel { CidadeID = 28, Nome = "Maringá", EstadoID = 16 },
                new CidadesModel { CidadeID = 29, Nome = "Ponta Grossa", EstadoID = 16 },
                new CidadesModel { CidadeID = 30, Nome = "Cascavel", EstadoID = 16 },

                // Rio Grande do Sul (RS)
                new CidadesModel { CidadeID = 31, Nome = "Porto Alegre", EstadoID = 21 },
                new CidadesModel { CidadeID = 32, Nome = "Caxias do Sul", EstadoID = 21 },
                new CidadesModel { CidadeID = 33, Nome = "Pelotas", EstadoID = 21 },
                new CidadesModel { CidadeID = 34, Nome = "Santa Maria", EstadoID = 21 },
                new CidadesModel { CidadeID = 35, Nome = "Canoas", EstadoID = 21 },

                // Ceará (CE)
                new CidadesModel { CidadeID = 36, Nome = "Fortaleza", EstadoID = 6 },
                new CidadesModel { CidadeID = 37, Nome = "Caucaia", EstadoID = 6 },
                new CidadesModel { CidadeID = 38, Nome = "Juazeiro do Norte", EstadoID = 6 },
                new CidadesModel { CidadeID = 39, Nome = "Maracanaú", EstadoID = 6 },
                new CidadesModel { CidadeID = 40, Nome = "Sobral", EstadoID = 6 },

                // Pernambuco (PE)
                new CidadesModel { CidadeID = 41, Nome = "Recife", EstadoID = 17 },
                new CidadesModel { CidadeID = 42, Nome = "Jaboatão dos Guararapes", EstadoID = 17 },
                new CidadesModel { CidadeID = 43, Nome = "Olinda", EstadoID = 17 },
                new CidadesModel { CidadeID = 44, Nome = "Caruaru", EstadoID = 17 },
                new CidadesModel { CidadeID = 45, Nome = "Petrolina", EstadoID = 17 }
            );

            // Inserção de pontos turísticos
            modelBuilder.Entity<LocaisModel>().HasData(
                new LocaisModel { Id = 1, Nome = "Basílica de São Bento", Descricao = "Igreja histórica com bela arquitetura", Endereco = "Praça Dr. Nemezio V. Souza, 50 - Centro, Marília - SP", CidadeID = 1, EstadoID = 25 },
                new LocaisModel { Id = 2, Nome = "Bosque Municipal", Descricao = "Área verde para caminhadas e lazer", Endereco = "Av. República, 1500 - Bosque, Marília - SP", CidadeID = 1, EstadoID = 25 },
                new LocaisModel { Id = 3, Nome = "Museu de Paleontologia", Descricao = "Museu com fósseis e exposições históricas", Endereco = "Rua São Paulo, 255 - Centro, Marília - SP", CidadeID = 1, EstadoID = 25 },
                new LocaisModel { Id = 4, Nome = "Parque do Povo", Descricao = "Ótimo para caminhadas e lazer ao ar livre", Endereco = "Rua Comendador José G. dos Santos, s/n - Centro, Tupã - SP", CidadeID = 2, EstadoID = 25 },
                new LocaisModel { Id = 5, Nome = "Museu Índia Vanuíre", Descricao = "Centro cultural com exposições sobre a história indígena", Endereco = "Rua Tupi, 1825 - Centro, Tupã - SP", CidadeID = 2, EstadoID = 25 },

                new LocaisModel { Id = 6, Nome = "Pelourinho", Descricao = "Centro histórico de Salvador", Endereco = "Praça Terreiro de Jesus, s/n - Pelourinho, Salvador - BA", CidadeID = 16, EstadoID = 5 },
                new LocaisModel { Id = 7, Nome = "Farol da Barra", Descricao = "Um dos cartões postais da Bahia", Endereco = "Avenida Oceanica, s/n - Barra, Salvador - BA", CidadeID = 16, EstadoID = 5 },
                new LocaisModel { Id = 8, Nome = "Praia do Forte", Descricao = "Destino turístico famoso na Bahia", Endereco = "Rua do Farol, 100 - Praia do Forte, Mata de São João - BA", CidadeID = 17, EstadoID = 5 },

                new LocaisModel { Id = 9, Nome = "Praça da Liberdade", Descricao = "Ponto histórico e cultural", Endereco = "Praça da Liberdade, s/n - Liberdade, Belo Horizonte - MG", CidadeID = 21, EstadoID = 13 },
                new LocaisModel { Id = 10, Nome = "Ouro Preto", Descricao = "Cidade histórica famosa", Endereco = "Praça Tiradentes, s/n - Centro, Ouro Preto - MG", CidadeID = 22, EstadoID = 13 },

                new LocaisModel { Id = 11, Nome = "Jardim Botânico", Descricao = "Um dos principais pontos turísticos de Curitiba", Endereco = "Rua Engenheiro Ostoja Roguski, 100 - Jardim Botânico, Curitiba - PR", CidadeID = 26, EstadoID = 16 },
                new LocaisModel { Id = 12, Nome = "Ópera de Arame", Descricao = "Teatro em meio à natureza", Endereco = "Avenida João Gualberto, 550 - Abranches, Curitiba - PR", CidadeID = 26, EstadoID = 16 },

                new LocaisModel { Id = 13, Nome = "Parque da Redenção", Descricao = "Ótimo para lazer e piqueniques", Endereco = "Parque da Redenção, s/n - Farroupilha, Porto Alegre - RS", CidadeID = 31, EstadoID = 21 },
                new LocaisModel { Id = 14, Nome = "Gramado", Descricao = "Cidade turística com forte influência europeia", Endereco = "Rua São Pedro, 225 - Centro, Gramado - RS", CidadeID = 32, EstadoID = 21 },

                new LocaisModel { Id = 15, Nome = "Praia de Jericoacoara", Descricao = "Uma das praias mais bonitas do Brasil", Endereco = "Rua do Forró, s/n - Jericoacoara, Jericoacoara - CE", CidadeID = 36, EstadoID = 6 },
                new LocaisModel { Id = 16, Nome = "Beira Mar de Fortaleza", Descricao = "Ponto turístico famoso", Endereco = "Avenida Beira Mar, s/n - Meireles, Fortaleza - CE", CidadeID = 36, EstadoID = 6 },

                new LocaisModel { Id = 17, Nome = "Porto de Galinhas", Descricao = "Praia paradisíaca", Endereco = "Rua Beira Mar, s/n - Porto de Galinhas, Ipojuca - PE", CidadeID = 41, EstadoID = 17 },
                new LocaisModel { Id = 18, Nome = "Marco Zero", Descricao = "Local histórico no Recife Antigo", Endereco = "Praça do Marco Zero, s/n - Recife Antigo, Recife - PE", CidadeID = 41, EstadoID = 17 }
                );


            modelBuilder.Entity<LocaisModel>()
                 .HasOne(l => l.CidadeRelacao)
                 .WithMany()
                 .HasForeignKey(l => l.CidadeID)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LocaisModel>()
                .HasOne(l => l.EstadoRelacao)
                .WithMany()
                .HasForeignKey(l => l.EstadoID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CidadesModel>()
                .HasOne(c => c.EstadoRelacao)
                .WithMany(e => e.Cidades)
                .HasForeignKey(c => c.EstadoID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EstadosModel>()
                .HasMany(e => e.Cidades)
                .WithOne(c => c.EstadoRelacao)
                .HasForeignKey(c => c.EstadoID);
        }
    }
}
