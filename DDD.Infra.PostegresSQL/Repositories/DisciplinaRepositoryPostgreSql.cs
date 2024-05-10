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
    public class DisciplinaRepositoryPostgreSql : IDisciplinaRepository
    {
        private readonly PostgresContext _context;

        public DisciplinaRepositoryPostgreSql(PostgresContext context)
        {
            _context = context;
        }


        public void DeleteDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Set<Disciplina>().Remove(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Disciplina> GetDisciplinas()
        {
            return _context.Disciplinas.ToList();
        }

        public Disciplina GetDisciplinaById(int id)
        {
            return _context.Disciplinas.Find(id);
        }

        public void InsertDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Disciplinas.Add(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception

            }
        }

        public void UpdateDisciplina(Disciplina disciplina)
        {
            try
            {
                _context.Entry(disciplina).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
