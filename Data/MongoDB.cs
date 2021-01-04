using System;
using ApiPessoas.Data.Collections;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace ApiPessoas.Data
{
    public class MongoDB
    {
        public IMongoDatabase DB{get;} 
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["nomeBanco"]);
                MapClasses();
            }
            catch (Exception ex)
            {    
                throw new MongoException("Não foi posivel conectar ao MongoDB",ex);
            }
        }  
        private void MapClasses()
        {
            var conventionPack = new ConventionPack{new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            //se não tiver nenhuma classe mapeada, faz o mapeamento
            if (!BsonClassMap.IsClassMapRegistered(typeof(Pessoa)))
            {
                BsonClassMap.RegisterClassMap<Pessoa>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}