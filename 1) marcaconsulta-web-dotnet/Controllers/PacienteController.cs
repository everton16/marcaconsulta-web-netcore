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
    public class PacienteController : Controller
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly IPacienteService _pacienteService;
        public PacienteController(
            ILogger<PacienteController> logger,
            IPacienteService pacienteService
            
            )
        {
            _logger = logger;
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaPaciente = _pacienteService.ListarRegistros();
            List<PacienteModel> listaPacienteModel = new List<PacienteModel>(); 

            foreach (var item in listaPaciente){

                var itemPaciente = new PacienteModel(){

                    Id = item.Id,
                    Cpf = item.Cpf,
                    Nome = item.Nome,
                    Telefone = item.Telefone,
                    Endereco = item.Endereco,
                    Bairro = item.Bairro,
                    CidadeNome = item.Cidade.Nome,
                    EstadoNome = item.Cidade.Estado.Nome,

                };

                listaPacienteModel.Add(itemPaciente);
                
            }


            ViewBag.listaPaciente = listaPacienteModel;

            return View();
        }

        //Editar registro específico
        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            if(Id != null)
            
            {
                var paciente = _pacienteService.RetornarRegistro((int)Id);

                var pacienteModel = new PacienteModel()
                {

                    Id = paciente.Id,
                    Nome = paciente.Nome,
                    Cpf = paciente.Cpf,
                    Telefone = paciente.Telefone,
                    Endereco = paciente.Endereco,
                    Bairro = paciente.Bairro,
                    CidadeId = paciente.CidadeId,

                };
                    return View(pacienteModel);
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
        public IActionResult Cadastrar(PacienteModel model)
        {
            
            var paciente = new Paciente()
            {
                Id = model.Id,
                Nome = model.Nome,
                Cpf = model.Cpf,
                Endereco = model.Endereco,
                Telefone = model.Telefone,
                Bairro = model.Bairro,
                CidadeId = model.CidadeId,

            };

            _pacienteService.Cadastrar(paciente);
            return RedirectToAction("Index");
        }

        //Exclui registro
        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            
            _pacienteService.Excluir((int)Id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}