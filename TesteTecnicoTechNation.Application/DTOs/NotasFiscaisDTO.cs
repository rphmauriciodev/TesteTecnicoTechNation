using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTechNation.Application.DTOs
{
    public class NotaFiscalDTO
    {
        public int ID_Nota {  get; private set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome_Pagador { get; private set; }

        [Required(ErrorMessage = "A data de emissão é obrigatória")]
        public DateTime DT_Emissao { get; private set; }

        [Required(ErrorMessage = "A data de cobrança é obrigatória")]
        public DateTime? DT_Cobranca { get; private set; }

        [Required(ErrorMessage = "A data de pagamento é obrigatória")]
        public DateTime? DT_Pagamento { get; private set; }

        [Required(ErrorMessage = "O valor da nota é obrigatório")]
        public double VL_Nota { get; private set; }

        [Required(ErrorMessage = "O documento da nota é obrigatório")]
        public string Documento_Nota { get; private set; }

        [Required(ErrorMessage = "O documento do boleto é obrigatório")]
        public string Documento_Boleto { get; private set; }

        [Required(ErrorMessage = "O status da nota é obrigatório")]
        public string ST_Nota { get; private set; }
    }
}
