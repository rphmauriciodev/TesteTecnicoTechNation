using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;
using TesteTecnicoTechNation.Domain.Entities;

namespace TesteTecnicoTechNation.Domain.Validation
{
    public class NotaFiscalValidator
    {
        public void Validate(int id_nota,
                            string nome_pagador,
                            DateTime dt_emissao,
                            DateTime dt_cobranca,
                            DateTime dt_pagamento,
                            double vl_nota,
                            string documento_nota,
                            string documento_boleto,
                            string st_nota)
        {
            DomainExceptionValidation.When(id_nota <= 0, "Nota fiscal sem identificação");
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome_pagador), "Nome do pagador é obrigatório.");
            DomainExceptionValidation.When(dt_cobranca < dt_emissao, "Data de cobrança não pode ser antes da emissão.");
            DomainExceptionValidation.When(dt_pagamento < dt_cobranca, "Data de pagamento não pode ser antes da cobrança.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(documento_nota), "O documento da nota é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(documento_boleto), "O documento do boleto é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(st_nota), "O status da nota é obrigatório.");
        }
    }
}
