using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;
using TesteTecnicoTechNation.Domain.Validation;

namespace TesteTecnicoTechNation.Domain.Entities
{
    public sealed class NotaFiscal
    {
        public int ID_Nota { get; private set; }
        public string Nome_Pagador { get; private set; }
        public DateTime DT_Emissao { get; private set; }
        public DateTime DT_Cobranca { get; private set; }
        public DateTime DT_Pagamento { get; private set; }
        public double VL_Nota { get; private set; }
        public string Documento_Nota { get; private set; }
        public string Documento_Boleto { get; private set; }
        public int ID_Status { get; private set; }
        public string ST_Nota { get; private set; }
    }
}
