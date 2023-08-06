using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using marcaconsulta_web_dotnet_domain.Entities;
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
                    ProfissionalNome = item.Profissional.Nome,
                    Data = item.Data,
                    HoraInicio = item.HoraInicio,
                    HoraFim = item.HoraFim
                };

                listaProfissionalAgendaModel.Add(itemProfissionalAgenda);
                
            }


            ViewBag.listaProfissionalAgenda = listaProfissionalAgendaModel;
            
            return View();
        }



           //TODO: fazer os endpoints 
//Editar registro específico
        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if(Id != null)
            
            {
                var profissionalAgenda = _profissionalAgendaService.RetornarRegistro((int)Id);

                var profissionalAgendaModel = new ProfissionalAgendaModel()
                {

                    Id = profissionalAgenda.Id,
                    ProfissionalId = profissionalAgenda.ProfissionalId,
                    Data = profissionalAgenda.Data,
                    HoraInicio = profissionalAgenda.HoraInicio,
                    HoraFim = profissionalAgenda.HoraFim

                };
                    return View(profissionalAgendaModel);
            }
            else
            {

                return View();
            } 
        }

        //Cadastra ou atualiza registro
        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(ProfissionalAgendaModel model)
        {
            
            var profissionalAgenda = new ProfissionalAgenda()
            {
                Id = model.Id,
                ProfissionalId = model.ProfissionalId,
                Data = model.Data,
                HoraInicio = model.HoraInicio,
                HoraFim = model.HoraFim
            };

            _profissionalAgendaService.Cadastrar(profissionalAgenda);
            return RedirectToAction("Index");
        }

        //Exclui registro
        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            
            _profissionalAgendaService.Excluir((int)Id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}