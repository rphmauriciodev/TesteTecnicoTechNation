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
        Task<IEnumerable<NotaFiscalDTO>> GetNotasFiscais(char status = 'T');

        Task<IEnumerable<NotaFiscalDTO>> GetNotasFiscaisByMonth(DateTime data, char tipoData = 'N', char status = 'T');
        Task<NotaFiscalDTO> GetNotaFiscalById(int id);
        Task<IEnumerable<StatusDTO>> GetAllStatus();
    }
}
