using System;
namespace ApiPessoas.Data.Collections
{
    public class Pessoa
    {
        public Pessoa(string nome, DateTime dataNascimento, string cpf, string sexo)
        {
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Cpf = cpf;
            this.Sexo = sexo;
        }
        public string Nome {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Cpf {get; set;}
        public string Sexo {get; set;}
    }
}