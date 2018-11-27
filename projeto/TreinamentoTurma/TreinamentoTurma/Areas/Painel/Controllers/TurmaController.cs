using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Filters;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers 
{
    [Autenticacao(Roles = "_PROFESSOR_")]
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
            
            viewModel.ListaTurmas = Mapper.Map<List<TurmaViewModel>>(repositorio.ListarTurmas());
            
            if (id.HasValue)
            {
                //TODO: passar a chamada abaixo para um método na própria ViewModel chamado 
                //"Selecionar(int id)", pra torná-la reutilizável

                //antes do Mapper era viewModel.Turma
                viewModel =  Mapper.Map<TurmaViewModel>( viewModel.ListaTurmas.FirstOrDefault(x => x.Id == id.Value) );
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
            Turma mappedTurma = Mapper.Map<Turma>(viewModel);

            if (viewModel.Id > 0)
            {
                turmaRepositorio.Atualizar(mappedTurma);

                viewModel.ListaTurmas.ForEach((x) => 
                {
                    if (x.Id == viewModel.Id)
                    {
                        x.Descricao = viewModel.Descricao;
                        x.LimiteAlunos = viewModel.LimiteAlunos;
                    }
                });
            }
            else
            {
                viewModel.Id = turmaRepositorio.Inserir(mappedTurma);
                viewModel.ListaTurmas.Add(viewModel);
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
            //turmas.Add(new SelectListItem()
            //{
            //    Text = "Turma de programação .Net",
            //    Value = "1"
            //});

            //turmas.Add(new SelectListItem()
            //{
            //    Text = "Turma de programação Java",
            //    Value = "2"
            //});

            //turmas.Add(new SelectListItem()
            //{
            //    Text = "Turma de programação PHP",
            //    Value = "3"
            //});

            TurmaRepositorio repositorio = new TurmaRepositorio();
            var listaDeTurmas = repositorio.ListarTurmas();
            //for (int i = 0; i < listaDeTurmas.Count; i++)
            //{
            //    turmas.Add(new SelectListItem()
            //    {
            //        Text = listaDeTurmas[i].Descricao,
            //        Value = listaDeTurmas[i].Id.ToString()
            //    });
            //}

            turmas = ListarTurmas(repositorio);

            ViewBag.Turmas = turmas;

            return View();
        }

        private List<SelectListItem> ListarTurmas(TurmaRepositorio repositorio) 
        {
            return repositorio 
                .ListarTurmas()
                .Select(x => new SelectListItem
                {
                    Text = x.Descricao,
                    Value = x.Id.ToString()
                }).ToList();
        }

        [HttpPost]
        public ActionResult Inscricao(Inscricao inscricao)
        {
            inscricao.AlunoId = 1;
            inscricao.InscritoEm = DateTime.Now;
            TurmaRepositorio repositorio = new TurmaRepositorio();

            if(repositorio.BuscarInscricao(inscricao.AlunoId, inscricao.TurmaId) == null)
            {
                repositorio.Inserir(inscricao);
            }
            else
            {
                ModelState.AddModelError("", "Este aluno já está inscrito nesta turma");
            }

            ViewBag.Turmas = ListarTurmas(repositorio);

            return View();
        }
    }
}



//if (!ModelState.IsValid)
//{
//    return View(turma);
//}