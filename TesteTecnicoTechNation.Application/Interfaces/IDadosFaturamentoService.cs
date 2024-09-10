using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTechNation.Application.DTOs;
using TesteTecnicoTechNation.Domain.Entities;

namespace TesteTecnicoTechNation.Application.Interfaces
{
	public interface IDadosFaturamentoService
	{
		Task<IEnumerable<DadosGeraisDTO>> GetDadosGerais(int? month = null, int? final_month = null, int? year = null);
		Task<decimal> GetTotal(int? month = null, int? final_month = null, int? year = null);
		Task<decimal> GetTotalAVencer(int? month = null, int? final_month = null, int? year = null);
        Task<IEnumerable<ReceitaDTO>> GetReceitaByYear(int? year = null);
        Task<IEnumerable<InadimplenciaDTO>> GetInadimplenciaByYear(int? year = null);
    }
}
