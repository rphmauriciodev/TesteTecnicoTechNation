using TesteTecnicoTechNation.Application.DTOs;

namespace TesteTecnicoTechNation.WebUI.Models
{
	public class DashboardDataViewModel
	{
		public decimal totalAVencer { get; set; }
		public decimal total { get; set; }
		public IEnumerable<DadosGeraisDTO> dadosGerais { get; set; }
		public IEnumerable<InadimplenciaDTO> inadimplencias { get; set; }
		public IEnumerable<ReceitaDTO> receitas { get; set; }
	}
}
