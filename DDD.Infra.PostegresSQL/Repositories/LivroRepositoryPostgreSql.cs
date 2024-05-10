using DDD.Domain.BibliotecaContext;
using DDD.Domain.SecretariaContext;
using DDD.Infra.PostegresSQL;
using DDD.Infra.PostegresSQL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infra.PostegresSQL.Repositories
{
    public class LivroRepositoryPostgreSql : ILivroRepository
    {
        private readonly PostgresContext _context;

        public LivroRepositoryPostgreSql(PostgresContext context)
        {
            _context = context;
        }
        public void DeleteLivro(Livro livro)
        {
            try
            {
                _context.Set<Livro>().Remove(livro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Livro GetLivroById(int id)
        {
            return _context.Livros.Find(id);
        }

        public List<Livro> GetLivros()
        {
            return _context.Livros.ToList();
        }

        public void InsertLivro(Livro livro)
        {
            try
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateLivro(Livro livro)
        {
            try
            {
                _context.Entry(livro).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
