using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfacaoCast.Repository.Contratos
{
    public class ListagemVoto
    {
        public DateTime Dia { get; set; }
        public int QuantidadeVotoMuitoInsatisfeito { get; set; }
        public int QuantidadeVotoInsatisfeito { get; set; }
        public int QuantidadeVotNeutro { get; set; }
        public int QuantidadeVotSatisfeito { get; set; }
        public int QuantidadeVotoMuitoSatisfeito { get; set; }
    }
}
