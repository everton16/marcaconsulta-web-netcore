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
    public class AgendamentoController : Controller
    {
        private readonly ILogger<AgendamentoController> _logger;
        private readonly IAgendamentoService _agendamentoService;
        public AgendamentoController(
            ILogger<AgendamentoController> logger,
            IAgendamentoService agendamentoService
            
            )
        {
            _logger = logger;
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaAgendamento = _agendamentoService.ListarRegistros();
            List<AgendamentoModel> listaAgendamentoModel = new List<AgendamentoModel>(); 

            foreach (var item in listaAgendamento){

                var itemAgendamento = new AgendamentoModel(){

                    Id = item.Id,
                    PacienteId = item.PacienteId,
                    ProfissionalAgendaId = item.ProfissionalAgendaId
                    
                };

                listaAgendamentoModel.Add(itemAgendamento);
                
            }


            ViewBag.listaAgendamento = listaAgendamentoModel;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}