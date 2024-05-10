using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.PostegresSQL
{
    public class PostgresContext : DbContext
    {
        private IConfiguration _configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Matricula>().HasKey(m => new { m.AlunoId, m.DisciplinaId });
            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Disciplinas)
                .WithMany(e => e.Alunos)
                .UsingEntity<Matricula>();

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Livros)
                .WithMany(e => e.Alunos)
                .UsingEntity<Emprestimo>();

            modelBuilder.Entity<User>().UseTpcMappingStrategy();
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Bibliotecaria>().ToTable("Bibliotecaria");

            //https://learn.microsoft.com/pt-br/ef/core/modeling/inheritance
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Bibliotecaria> Bibliotecarias { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        public PostgresContext(IConfiguration configuration, DbContextOptions options) :base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionString = _configuration.GetConnectionString(typeDatabase);

            if (typeDatabase == "SqlServer")
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else if (typeDatabase == "Postgresql")
            {
                optionsBuilder.UseNpgsql(connectionString);
            }

        }
    }
}
