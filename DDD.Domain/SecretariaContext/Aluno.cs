using DDD.Domain.BibliotecaContext;
using DDD.Domain.UserManagementContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.SecretariaContext
{
    public class Aluno : User
    {
        private DateTime dataCadastro;

        public Aluno(string nome, string sobrenome, string email, string login, string senha, string senha1, DateTime dataCadastro, bool ativo)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Login = login;
            Senha = senha;
            this.dataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public IList<Disciplina>? Disciplinas { get; set; }

        public IList<Livro>? Livros { get; set; }






        //public IList<Matricula>? Matriculas { get; set; }

    }
}
