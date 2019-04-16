using SatisfacaoCast.Repository;
using SatisfacaoCast.Repository.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SatisfacaoCast.Controllers
{
    public class VotoApiController : ApiController
    {
        private readonly VotoRepository _votorepo;

        public VotoApiController()
        {
            this._votorepo = new VotoRepository();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public bool Votar(string idVoto)
        {
           return this._votorepo.Votar(new Repository.Contratos.Voto { TipoVoto = int.Parse(idVoto) });
        }

       [HttpGet]
       public IEnumerable<dynamic> ObterResultados(DateTime? filtro)
        {
            var lista = new List<Voto>();
            var results = this._votorepo.ObterResultadosVoto(filtro);
            return results;
        }

        [HttpGet]
        public int ObterContagemDeVotos()
        {
            var results = this._votorepo.ObterContagem();          
            return results;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}