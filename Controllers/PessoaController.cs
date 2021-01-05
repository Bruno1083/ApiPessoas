using ApiPessoas.Data.Collections;
using ApiPessoas.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiPessoas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Pessoa> _pessoasCollection;   
        public PessoaController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _pessoasCollection = _mongoDB.DB.GetCollection<Pessoa>(typeof(Pessoa).Name.ToLower());
        }
        [HttpPost]
        public ActionResult SalvarPessoa([FromBody]PessoaDto dto)
        {
            var pessoa = new Pessoa(dto.Nome, dto.DataNascimento, dto.Cpf ,dto.Sexo);
            //Adicionar no banco
            _pessoasCollection.InsertOne(pessoa);
            return StatusCode(201, "Pessoa adicionado com sucesso");
        }
        [HttpGet]
        public ActionResult ObterPessoas()
        {
            var pessoas = _pessoasCollection.Find(Builders<Pessoa>.Filter.Empty).ToList();
            return Ok(pessoas);
        }
    }
}