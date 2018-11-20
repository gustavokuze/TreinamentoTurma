using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    public class TurmaController : Controller
    {
        // GET: Painel/Turma
        public ActionResult Index()
        {
            return View();
        }
          
        public ActionResult Cadastrar(int? id = null)
        {
            TurmaViewModel viewModel = new TurmaViewModel();
            TurmaRepositorio repositorio = new TurmaRepositorio();
            
            viewModel.ListaTurmas = repositorio.ListarTurmas();
            
            if (id.HasValue)
            {
                //TODO: passar a chamada abaixo para um método na própria ViewModel chamado 
                //"Selecionar(int id)", pra torná-la reutilizável
                viewModel.Turma = viewModel.ListaTurmas.FirstOrDefault(x => x.Id == id.Value);
            }
            
            return View(viewModel);
        }

        #region Action Edit
        /*
         A Action edit foi substituída pela própria action cadastrar, 
         que agora pode ou não receber um parâmetro
             */

        //public ActionResult Editar(int id = 0)
        //{
        //    TurmaRepositorio repositorio = new TurmaRepositorio();
        //    Turma turmaEdit = null;

        //    var turmas = repositorio.ListarTurmas();
        //    ViewBag.Turmas = turmas;
        //    if (id > 0)
        //    {
        //        turmaEdit = repositorio.BuscarTurmaPorId(id);
        //        ViewBag.TurmaEdit = turmaEdit;
        //        return View("Cadastrar", turmaEdit);
        //    }


        //    return RedirectToAction("Cadastrar");
        //}
        #endregion


        [HttpPost]
        public ActionResult Cadastrar(TurmaViewModel viewModel)
        {
            TurmaRepositorio turmaRepositorio = new TurmaRepositorio();

            if (viewModel.Turma.Id > 0)
            {
                turmaRepositorio.Atualizar(viewModel.Turma);

                viewModel.ListaTurmas.ForEach((x) => 
                {
                    if (x.Id == viewModel.Turma.Id)
                    {
                        x.Descricao = viewModel.Turma.Descricao;
                        x.LimiteAlunos = viewModel.Turma.LimiteAlunos;
                    }
                });
            }
            else
            {
                viewModel.Turma.Id = turmaRepositorio.Inserir(viewModel.Turma);
                viewModel.ListaTurmas.Add(viewModel.Turma);
            }

            return View(viewModel);
        }


        public ActionResult Excluir(int id = 0) 
        {
            TurmaRepositorio repositorio = new TurmaRepositorio();

            if(id > 0)
            {
                repositorio.Excluir(id);
            }
            
            return RedirectToAction("Cadastrar");
        }

        public ActionResult Inscricao()
        {
            List<SelectListItem> turmas = new List<SelectListItem>();
            turmas.Add(new SelectListItem()
            {
                Text = "Turma de programação .Net",
                Value = "1"
            });

            turmas.Add(new SelectListItem()
            {
                Text = "Turma de programação Java",
                Value = "2"
            });

            turmas.Add(new SelectListItem()
            {
                Text = "Turma de programação PHP",
                Value = "3"
            });

            ViewBag.Turmas = turmas;

            return View();
        }

        [HttpPost]
        public ActionResult Inscricao(Inscricao inscricao)
        {
            return View();
        }
    }
}



//if (!ModelState.IsValid)
//{
//    return View(turma);
//}