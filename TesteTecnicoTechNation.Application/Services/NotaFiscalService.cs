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
        private enum StatusNotaFiscal
        {
            Todas = 0,
            Emitida = 1,
            Cobranca = 2,
            Atraso = 3,
            Pago = 4
        }
        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository, IMapper mapper)
        {
            _notaFiscalRepository = notaFiscalRepository ??
                throw new ArgumentNullException(nameof(notaFiscalRepository));
            _mapper = mapper;
        }
        public async Task<IEnumerable<NotaFiscalDTO>> GetNotasFiscais(char status = 'T')
        {
            int id_status = GetIdStatus(status);
            var notaFiscalEntity = await _notaFiscalRepository.GetNotasFiscais(id_status);
            return _mapper.Map<IEnumerable<NotaFiscalDTO>>(notaFiscalEntity);
        }
        public async Task<IEnumerable<NotaFiscalDTO>> GetNotasFiscaisByMonth(DateTime data, char tipoData = 'N', char status = 'T')
        {
            int month = data.Month;
            int year = data.Year;
            int id_status = GetIdStatus(status);
            var notaFiscalEntity = await _notaFiscalRepository.GetNotasFiscaisByMonth(month, year, tipoData, id_status);
            return _mapper.Map<IEnumerable<NotaFiscalDTO>>(notaFiscalEntity);
        }
        public async Task<NotaFiscalDTO> GetNotaFiscalById(int id)
        {
            var notaFiscalEntity = await _notaFiscalRepository.GetNotaFiscalById(id);
            return _mapper.Map<NotaFiscalDTO>(notaFiscalEntity);
        }
        private int GetIdStatus(char status)
        {
            return status switch
            {
                'E' => (int)StatusNotaFiscal.Emitida,
                'C' => (int)StatusNotaFiscal.Cobranca,
                'A' => (int)StatusNotaFiscal.Atraso,
                'P' => (int)StatusNotaFiscal.Pago,
                _ => (int)StatusNotaFiscal.Todas,
            };
        }
    }
}
