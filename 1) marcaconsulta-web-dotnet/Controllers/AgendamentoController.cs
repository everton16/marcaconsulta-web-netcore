using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using marcaconsulta_web_dotnet_domain.Entities;
using marcaconsulta_web_dotnet_service.Interfaces;
using marcaconsulta_web_netcore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace marcaconsulta_web_netcore.Controllers
{
    [Route("[controller]")]
    public class AgendamentoController : Controller
    {
        private readonly ILogger<AgendamentoController> _logger;
        private readonly IAgendamentoService _agendamentoService;
        private readonly IProfissionalAgendaService _profissionalAgendaService;
        private readonly IProfissionalService _profissionalService;
        public AgendamentoController(
            ILogger<AgendamentoController> logger,
            IAgendamentoService agendamentoService,
            IProfissionalAgendaService profissionalAgendaService,
            IProfissionalService profissionalService
            
            )
        {
            _logger = logger;
            _agendamentoService = agendamentoService;
            _profissionalAgendaService = profissionalAgendaService;
            _profissionalService = profissionalService;
        }

        //Listagem Agendamentos
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

        //Editar registro específico
        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {

            var ListaProfissionalAgendas = new SelectList(_profissionalAgendaService.ListarRegistros(),"Id", "Data");
            
            var itemAgendamento = new AgendamentoModel()
                {
                  ListaProfissionalAgendas = ListaProfissionalAgendas
                };

            if(Id != null)
            
            {
                var agendamento = _agendamentoService.RetornarRegistro((int)Id);
                
                    itemAgendamento.Id = agendamento.Id;
                    itemAgendamento.PacienteId = agendamento.PacienteId;
                    itemAgendamento.ProfissionalAgendaId = agendamento.ProfissionalAgendaId;

                };
                    return View(itemAgendamento);
        }

        //Cadastra
        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(AgendamentoModel model)
        {
            
            var agendamento = new Agendamento()
            {
                Id = model.Id,
                PacienteId = model.PacienteId,
                ProfissionalAgendaId = model.ProfissionalAgendaId,
            };

            _agendamentoService.Cadastrar(agendamento);
            return RedirectToAction("Index");
        }

        //Exclui registro
        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            
            _agendamentoService.Excluir((int)Id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}