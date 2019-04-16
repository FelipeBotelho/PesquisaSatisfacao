using SatisfacaoCast.Repository.Contratos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SatisfacaoCast.Repository
{
    public class VotoRepository
    {
        public bool Votar(Contratos.Voto v)
        {
            try
            {
                using (var db = new Entities())
                {
                    var voto = new VOTO()
                    {
                        IdTipoVoto = v.TipoVoto,
                        Data_Voto = DateTime.Now
                    };
                    db.VOTO.Add(voto);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<dynamic> ObterResultadosVoto(DateTime? filtro)
        {
            using (var db = new Entities())
            {
                var votos = db.VOTO.Include("TIPOVOTO").Where(x => DbFunctions.TruncateTime(x.Data_Voto) == DbFunctions.TruncateTime(filtro) || filtro == null).GroupBy(x => DbFunctions.TruncateTime(x.Data_Voto)).Select(x => new
                {
                    QuantidadeTotal = x.Count(),
                    QuantidadeMuitoInsatisfeito = x.Count(y=>y.IdTipoVoto == (int)EnumTipoVoto.MuitoInsatisfeito),
                    QuantidadeInsatisfeito = x.Count(y => y.IdTipoVoto == (int)EnumTipoVoto.Instatisfeito),
                    QuantidadeNeutro = x.Count(y => y.IdTipoVoto == (int)EnumTipoVoto.Neutro),
                    QuantidadeSatisfeito = x.Count(y => y.IdTipoVoto == (int)EnumTipoVoto.Satisfeito),
                    QuantidadeMuitoSatisfeito = x.Count(y => y.IdTipoVoto == (int)EnumTipoVoto.MuitoSatisfeito),
                    Day = (DateTime)x.Key
                }).ToList();


                return votos;
            }
        }

        public int ObterContagem()
        {
            using (var db = new Entities())
            {
                return db.VOTO.Count();
            }
        }
    }
}
