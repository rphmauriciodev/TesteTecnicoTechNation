using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
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
            var status = await _notaFiscalService.GetAllStatus();
            ViewBag.Status = status;
            return View(notas);
        }
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var notas = await _notaFiscalService.GetNotasFiscais();
            return PartialView("_ListarNotas", notas);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByStatus([FromQuery] char status)
        {
            var notas = await _notaFiscalService.GetNotasFiscais(status);
            return PartialView("_ListarNotas", notas);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByDate([FromQuery] char tipo_data, [FromQuery] DateTime date)
        {
            var notas = await _notaFiscalService.GetNotasFiscaisByMonth(date, tipo_data);
            return PartialView("_ListarNotas", notas);
        }

        [HttpGet]
        public async Task<IActionResult> FilterByDateAndStatus([FromQuery] char tipo_data, [FromQuery] char status, [FromQuery] DateTime date)
        {
            var notas = await _notaFiscalService.GetNotasFiscaisByMonth(date, tipo_data, status);
            return PartialView("_ListarNotas", notas);
        }
    }
}
