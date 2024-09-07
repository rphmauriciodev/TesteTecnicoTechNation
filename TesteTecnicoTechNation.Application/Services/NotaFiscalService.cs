using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteTecnicoTechNation.Application.DTOs;
using TesteTecnicoTechNation.Application.Interfaces;
using TesteTecnicoTechNation.Domain.Interfaces.Repositories;

namespace TesteTecnicoTechNation.Application.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IMapper _mapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository, IMapper mapper)
        {
            _notaFiscalRepository = notaFiscalRepository ??
                throw new ArgumentNullException(nameof(notaFiscalRepository));
            _mapper = mapper;
        }
        public async Task<IEnumerable<NotaFiscalDTO>> GetAllNotasFiscais()
        {
            var notaFiscalEntity = await _notaFiscalRepository.GetAllNotasFiscais();
            return _mapper.Map<IEnumerable<NotaFiscalDTO>>(notaFiscalEntity);
        }
        public async Task<NotaFiscalDTO> GetNotaFiscalById(int id)
        {
            var notaFiscalEntity = await _notaFiscalRepository.GetNotaFiscalById(id);
            return _mapper.Map<NotaFiscalDTO>(notaFiscalEntity);
        }
    }
}
