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
       public IEnumerable<Voto> ObterResultados(DateTime? filtro)
        {
            var lista = new List<Voto>();
            var results = this._votorepo.ObterResultadosVoto(filtro);
            foreach (var item in results)
            {
                var v = new Voto() {
                    Id = item.Id,
                    Data = item.Data_Voto ?.Date,
                    NomeTipoVoto = item.TIPOVOTO.DESCRICAO
                };
                lista.Add(v);
            }
            return lista;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}