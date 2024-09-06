using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTechNation.Domain.Entities;

namespace TesteTecnicoTechNation.Domain.Interfaces.Repositories
{
    public interface INotaFiscalRepository
    {
        Task<IEnumerable<NotaFiscal>> GetAllNotaFiscals();
        Task<NotaFiscal> GetNotaFiscalById(int id);
    }
}
