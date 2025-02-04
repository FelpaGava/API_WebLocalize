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

            // Configuração da relação entre as tabelas
            modelBuilder.Entity<LocaisModel>()
                 .HasOne(l => l.EstadoRelacao)
                 .WithMany()
                 .HasForeignKey(l => l.EstadoID)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CidadesModel>()
                .HasOne(c => c.EstadoRelacao)
                .WithMany(e => e.Cidades)  
                .HasForeignKey(c => c.EstadoID);

            modelBuilder.Entity<EstadosModel>()
                .HasMany(e => e.Cidades) 
                .WithOne(c => c.EstadoRelacao)  
                .HasForeignKey(c => c.EstadoID);
        }
    }
}
