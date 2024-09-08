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
        Task<IEnumerable<NotaFiscal>> GetNotasFiscais(int status);
        Task<NotaFiscal> GetNotaFiscalById(int id);
        Task<IEnumerable<NotaFiscal>> GetNotasFiscaisByMonth(int month, int year, char tipo_data, int id_status);
    }
}
