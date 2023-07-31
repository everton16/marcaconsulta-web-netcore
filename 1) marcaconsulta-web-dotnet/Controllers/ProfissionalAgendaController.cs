using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using marcaconsulta_web_dotnet_service.Interfaces;
using marcaconsulta_web_netcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace marcaconsulta_web_netcore.Controllers
{
    [Route("[controller]")]
    public class ProfissionalAgendaController : Controller
    {
        private readonly ILogger<ProfissionalAgendaController> _logger;
        private readonly IProfissionalAgendaService _profissionalAgendaService;
        public ProfissionalAgendaController(
            ILogger<ProfissionalAgendaController> logger,
            IProfissionalAgendaService profissionalAgendaService
            
            )
        {
            _logger = logger;
            _profissionalAgendaService = profissionalAgendaService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaProfissionalAgenda = _profissionalAgendaService.ListarRegistros();
            List<ProfissionalAgendaModel> listaProfissionalAgendaModel = new List<ProfissionalAgendaModel>(); 

            foreach (var item in listaProfissionalAgenda){

                var itemProfissionalAgenda = new ProfissionalAgendaModel(){

                    Id = item.Id,
                    ProfissionalId = item.ProfissionalId,
                    Data = item.Data,
                    HoraInicio = item.HoraInicio,
                    HoraFim = item.HoraFim
                };

                listaProfissionalAgendaModel.Add(itemProfissionalAgenda);
                
            }


            ViewBag.listaProfissionalAgenda = listaProfissionalAgendaModel;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}