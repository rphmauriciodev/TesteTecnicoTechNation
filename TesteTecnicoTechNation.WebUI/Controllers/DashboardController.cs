using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTechNation.Application.Interfaces;
using TesteTecnicoTechNation.WebUI.Models;

namespace TesteTecnicoTechNation.WebUI.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IDadosFaturamentoService _dadosFaturamentoService;

		public DashboardController(IDadosFaturamentoService dadosFaturamentoService)
		{
			_dadosFaturamentoService = dadosFaturamentoService;
		}
		public async Task<IActionResult> Index()
		{
			var year = DateTime.Now.Year;
            ViewData["Ano"] = year;
            var dashboardData = new DashboardDataViewModel
			{
				totalAVencer = await _dadosFaturamentoService.GetTotalAVencer(),
				total = await _dadosFaturamentoService.GetTotal(),
				dadosGerais = await _dadosFaturamentoService.GetDadosGerais(),
                inadimplencias = await _dadosFaturamentoService.GetInadimplenciaByYear(),
                receitas = await _dadosFaturamentoService.GetReceitaByYear(),
            };

			return View();
		}

		public async Task<IActionResult> GetDashBoardData(int? month = null, int? final_month = null, int? year = null)
		{
            var dashboardData = new DashboardDataViewModel
			{
				totalAVencer = await _dadosFaturamentoService.GetTotalAVencer(month, final_month, year),
				total = await _dadosFaturamentoService.GetTotal(month, final_month, year),
				dadosGerais = await _dadosFaturamentoService.GetDadosGerais(month, final_month, year),
				inadimplencias = await _dadosFaturamentoService.GetInadimplenciaByYear(year),
				receitas = await _dadosFaturamentoService.GetReceitaByYear(year),
			};

            return Json(dashboardData);
		}
	}
}
