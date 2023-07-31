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
    public class ProfissionalController : Controller
    {
        private readonly ILogger<ProfissionalController> _logger;
        private readonly IProfissionalService _profissionalService;
        private readonly IEspecialidadeService _especialidadeService;
        public ProfissionalController(
            ILogger<ProfissionalController> logger,
            IProfissionalService profissionalService,
            IEspecialidadeService especialidadeService
            
            )
        {
            _logger = logger;
            _profissionalService = profissionalService;
            _especialidadeService = especialidadeService;
        }

        //Listagem registros
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var listaProfissional = _profissionalService.ListarRegistros();
            List<ProfissionalModel> listaProfissionalModel = new List<ProfissionalModel>(); 

            foreach (var item in listaProfissional){

                var itemProfissional = new ProfissionalModel(){

                    Id = item.Id,
                    Cpf = item.Cpf,
                    Nome = item.Nome,
                    Endereco = item.Endereco,
                    Bairro = item.Bairro,
                    Telefone = item.Telefone,
                    CidadeId = item.CidadeId,
                    UfId = item.UfId,
                    EspecialidadeId = item.EspecialidadeId

                };

                listaProfissionalModel.Add(itemProfissional);
                
            }


            ViewBag.listaProfissional = listaProfissionalModel;

            return View();
        }

        //Abre tela de cadastro
        [HttpGet]
        [Route("Profissional/Cadastrar")]
        public IActionResult Cadastrar()
        {
            return View();
        }
        
        //Editar registro específico
        [HttpGet]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(int? Id)
        {
            
            var ListaEspecialidades = new SelectList(_especialidadeService.ListarRegistros(), "id", "TextoEspecialidade");
            
            var itemProfissional = new ProfissionalModel ()
            {
                ListaEspecialidades = ListaEspecialidades    

            };
            
            if(Id != null)
            
            {
                var profissional = _profissionalService.RetornarRegistro((int)Id);

                
                    itemProfissional.Id = profissional.Id;
                    itemProfissional.Nome = profissional.Nome;
                    itemProfissional.Cpf = profissional.Cpf;
                    itemProfissional.Telefone = profissional.Telefone;
                    itemProfissional.Endereco = profissional.Endereco;
                    itemProfissional.Bairro = profissional.Bairro;
                    itemProfissional.CidadeId = profissional.CidadeId;
                    itemProfissional.UfId = profissional.UfId;
                    itemProfissional.EspecialidadeId = profissional.EspecialidadeId;

                }
                    return View(itemProfissional);
        }

        //Cadastra ou atualiza registro
        [HttpPost]
        [Route("Cadastrar")]
        [Route("Cadastrar/{Id}")]
        public IActionResult Cadastrar(ProfissionalModel model)
        {
            
            var profissional = new Profissional()
            {
                Id = model.Id,
                Nome = model.Nome,
                Cpf = model.Cpf,
                Endereco = model.Endereco,
                Telefone = model.Telefone,
                Bairro = model.Bairro,
                CidadeId = model.CidadeId,
                UfId = model.UfId,
                EspecialidadeId = model.EspecialidadeId

            };

            _profissionalService.Cadastrar(profissional);
            //return View();
            return RedirectToAction("Index");
        }

        //Exclui registro
        [HttpGet]
        [Route("Excluir/{Id}")]
        public IActionResult Excluir(int? Id)
        {
            
            _profissionalService.Excluir((int)Id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}