using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Domain.UserManagementContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.PostegresSQL
{
    public class PostegresContext : DbContext
    {
        public PostegresContext(DbContextOptions<PostegresContext> options) 
            : base(options) 
        { 
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Bibliotecaria> Bibliotecarias { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
