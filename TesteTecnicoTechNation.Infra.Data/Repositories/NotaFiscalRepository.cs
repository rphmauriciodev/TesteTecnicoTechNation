using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTechNation.Domain.Entities;
using TesteTecnicoTechNation.Domain.Interfaces.Repositories;

namespace TesteTecnicoTechNation.Infra.Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        public Task<IEnumerable<NotaFiscal>> GetAllNotaFiscals()
        {
            throw new NotImplementedException();
        }

        public Task<NotaFiscal> GetNotaFiscalById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
