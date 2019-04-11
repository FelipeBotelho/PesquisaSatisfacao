using System;
using System.Collections.Generic;
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

        public IEnumerable<VOTO> ObterResultadosVoto(DateTime? filtro)
        {
            using (var db = new Entities())
            {
                return filtro == null ? db.VOTO.Include("TIPOVOTO").ToList() : db.VOTO.Include("TIPOVOTO").Where(x => x.Data_Voto == filtro).ToList();
            }
        }
    }
}
