using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.PostegresSQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.PostegresSQL.Repositories
{
    public class EmprestimoRepositoryPostgreSql : IEmprestimoRepository
    {
        private readonly PostgresContext _context;

        public EmprestimoRepositoryPostgreSql(PostgresContext context)
        {
            _context = context;
        }
        public void DeleteEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                _context.Set<Emprestimo>().Remove(emprestimo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Emprestimo GetEmprestimoById(int id)
        {
            return _context.Emprestimos.Find(id);
        }

        public List<Emprestimo> GetEmprestimos()
        {
            return _context.Emprestimos.ToList();
        }

        public Emprestimo InsertEmprestimo(int idAluno, int idLivro)
        {
            var aluno = _context.Alunos.First(i => i.UserId == idAluno);
            var livro = _context.Livros.First(i => i.LivroId == idLivro);
            

            var emprestimo = new Emprestimo
            {
                Aluno = aluno,
                Livro = livro
                
            };

            try
            {

                _context.Add(emprestimo);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                var msg = ex.InnerException;
                throw;
            }

            return emprestimo;
        }

        public void UpdateEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                _context.Entry(emprestimo).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
