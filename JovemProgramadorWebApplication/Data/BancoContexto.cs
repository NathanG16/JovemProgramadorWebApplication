using JovemProgramadorWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using JovemProgramadorWebApplication.Data.Mapeamento;

namespace JovemProgramadorWebApplication.Data
{
    public class BancoContexto : DbContext
    {
        public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new AlunoMapeamento());
            modelBuilder.ApplyConfiguration(new ProfessorMapeamento());
            modelBuilder.ApplyConfiguration(new TurmaMapeamento());
        }

        public DbSet<Usuario> Usuario { get; set; } = null!;
        public DbSet<Aluno> Aluno { get; set; } = null!;
        public DbSet<Professor> Professor { get; set; } = null!;
        public DbSet<Turma> Turma { get; set; } = null!;
    }
}
