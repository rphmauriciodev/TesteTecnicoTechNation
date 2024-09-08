using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTechNation.Application.Interfaces;

namespace TesteTecnicoTechNation.WebUI.Controllers
{
    public class NotaFiscalController : Controller
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotaFiscalController(INotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var notas = await _notaFiscalService.GetNotasFiscais();
            return View(notas);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> FilterByStatus([FromRoute] char status)
        {
            var notas = await _notaFiscalService.GetNotasFiscais(status);
            return View("Index", notas);
        }

        [HttpGet("data/{tipo_data}")]
        public async Task<IActionResult> FilterByDate([FromRoute] char tipo_data, [FromQuery] DateTime date)
        {
            var notas = await _notaFiscalService.GetNotasFiscaisByMonth(date, tipo_data);
            return View("Index", notas);
        }

        [HttpGet("data/{tipo_data}/status/{status}")]
        public async Task<IActionResult> FilterByDateAndStatus([FromRoute] char tipo_data, [FromRoute] char status, [FromQuery] DateTime date)
        {
            var notas = await _notaFiscalService.GetNotasFiscaisByMonth(date, tipo_data);
            return View("Index", notas);
        }
    }
}
