using Microsoft.EntityFrameworkCore;

namespace EscolaBancoSemi.Models
{
    public class EscolaContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-B8CRO5N;
                Database=EscolaBancoSemi;Trusted_Connection=True;");
        }
    }
}
