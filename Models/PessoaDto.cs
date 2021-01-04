using System;

namespace ApiPessoas.Models
{
    public class PessoaDto
    {
        public string Nome {get; set;}
        public DateTime DataNascimento {get; set;}
        public string Cpf {get; set;}
        public string Sexo {get; set;}
    }
}