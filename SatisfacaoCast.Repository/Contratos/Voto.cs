using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfacaoCast.Repository.Contratos
{
    public class Voto
    {
        public int Id { get; set; }
        public int TipoVoto { get; set; }
        public string NomeTipoVoto { get; set; }
        public DateTime? Data { get; set; }
    }
}
