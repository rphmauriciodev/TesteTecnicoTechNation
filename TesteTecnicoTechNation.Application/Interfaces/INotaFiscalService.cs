using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTechNation.Application.DTOs;

namespace TesteTecnicoTechNation.Application.Interfaces
{
    public interface INotaFiscalService
    {
        Task<IEnumerable<NotaFiscalDTO>> GetAllNotasFiscais();
        Task<NotaFiscalDTO> GetNotaFiscalById(int id);
    }
}
