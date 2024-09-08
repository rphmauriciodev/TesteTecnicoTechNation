using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteTecnicoTechNation.Domain.Entities
{
    public sealed class Status
    {
        public char CD_Status { get; private set; }
        public string ST_Nota { get; private set; }
    }
}
