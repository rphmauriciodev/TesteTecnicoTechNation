using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteTecnicoTechNation.Application.DTOs;
using TesteTecnicoTechNation.Application.Interfaces;
using TesteTecnicoTechNation.Domain.Interfaces.Repositories;

namespace TesteTecnicoTechNation.Application.Services
{
	public class DadosFaturamentoService : IDadosFaturamentoService
	{
		private readonly IDadosFaturamentoRepository _dadosFaturamentoRepository;
		private readonly IMapper _mapper;
		public DadosFaturamentoService( IDadosFaturamentoRepository dadosFaturamentoRepository,
										IMapper mapper)
		{
			_dadosFaturamentoRepository = dadosFaturamentoRepository;
			_mapper = mapper;
		}
        public async Task<IEnumerable<DadosGeraisDTO>> GetDadosGerais(int? month = null, int? finalMonth = null, int? year = null)
        {
            var dados = await _dadosFaturamentoRepository.GetDadosGerais(month, finalMonth, year);

            var idDescricao = new Dictionary<int, string>
        {
            { 1, "Valor total das notas emitidas sem cobrança feita" },
            { 3, "Valor total das notas vencidas - Inadimplência" },
            { 4, "Valor total das notas pagas" }
        };

			return dados.Select(item => new DadosGeraisDTO
			(
				item.ID_Status,
				idDescricao.ContainsKey(item.ID_Status) ? idDescricao[item.ID_Status] : "Desconhecido",
				item.Valor_total
            )).ToList();
        }
        public async Task<decimal> GetTotal(int? month = null, int? final_month = null, int? year = null)
		{
			return await _dadosFaturamentoRepository.GetTotal(month, final_month, year);
		}
		public async Task<decimal> GetTotalAVencer(int? month = null, int? final_month = null, int? year = null)
		{
			var dataAtual = DateTime.Now;
			return await _dadosFaturamentoRepository.GetTotalAVencer(dataAtual);
		}
	}
}
