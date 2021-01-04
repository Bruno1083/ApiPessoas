using ApiPessoas.Data.Collections;
using ApiPessoas.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace ApiPessoas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Pessoa> _infectadosCollection;   
        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Pessoa>(typeof(Pessoa).Name.ToLower());
        }
        [HttpPost]
        public ActionResult SalvarInfectado([FromBody]PessoaDto dto)
        {
            var pessoa = new Pessoa(dto.Nome, dto.DataNascimento, dto.Cpf ,dto.Sexo);
            //Adicionar no banco
            _infectadosCollection.InsertOne(pessoa);
            return StatusCode(201, "Infectado adicionado com sucesso");
        }
        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Pessoa>.Filter.Empty).ToList();
            return Ok(infectados);
        }
    }
}