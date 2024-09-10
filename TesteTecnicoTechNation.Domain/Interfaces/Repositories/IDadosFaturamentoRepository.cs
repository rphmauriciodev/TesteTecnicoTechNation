using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTecnicoTechNation.Domain.Entities;

namespace TesteTecnicoTechNation.Domain.Interfaces.Repositories
{
	public interface IDadosFaturamentoRepository
	{
		Task<IEnumerable<DadosGerais>> GetDadosGerais(int? month = null, 
														int? final_month = null, 
														int? year = null);
		Task<decimal> GetTotal(int? month = null, int? final_month = null, int? year = null);
		Task<decimal> GetTotalAVencer(DateTime data_atual,
                                                    int? month = null,
                                                    int? final_month = null,
                                                    int? year = null);
	}
}
