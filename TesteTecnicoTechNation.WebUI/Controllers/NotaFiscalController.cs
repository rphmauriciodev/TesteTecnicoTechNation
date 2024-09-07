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
            var notas = await _notaFiscalService.GetAllNotasFiscais();
            return View(notas);
        }
    }
}
