using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Filters;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services;

namespace TreinamentoTurma.Areas.Painel.Controllers
{

    public class TurmaController : Controller
    {
        private TurmaService _turmaService { get; set; } = new TurmaService();

        // GET: Painel/Turma
        public ActionResult Index()
        {
            return View();
        }

        [Autenticacao(Roles = "_PROFESSOR_")]
        public ActionResult Cadastrar(int? id = null)
        {
            TurmaViewModel viewModel = new TurmaViewModel();

            var listaTurmas = Mapper.Map<List<TurmaViewModel>>(_turmaService.ListarTurmas());

            if (id.HasValue)
            {
                var turmaSelecionada = listaTurmas.First(x => x.Id == id);
                viewModel = turmaSelecionada;
                viewModel.ListaTurmas = listaTurmas;
                //viewModel.ListaTurmas.Remove(turmaSelecionada);
            }
            else
            {
                viewModel.ListaTurmas = listaTurmas;
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

        [Autenticacao(Roles = "_PROFESSOR_")]
        [HttpPost]
        public ActionResult Cadastrar(TurmaViewModel viewModel)
        {
            Turma mappedTurma = Mapper.Map<Turma>(viewModel);

            if (viewModel.Id > 0)
            {
                _turmaService.Atualizar(mappedTurma);

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
                viewModel.Id = _turmaService.Cadastrar(mappedTurma);
                viewModel.ListaTurmas.Add(viewModel);
            }

            return View(viewModel);
        }

        [Autenticacao(Roles = "_PROFESSOR_")]
        public ActionResult Excluir(int id = 0)
        {
            if (id > 0)
            {
                _turmaService.Excluir(id);
            }

            return RedirectToAction("Cadastrar");
        }

        private List<SelectListItem> ListarTurmas()
        {
            var turmas =  _turmaService.ListarTurmas();
            return turmas.Select(x => new SelectListItem
            {
                Text = x.Descricao,
                Value = x.Id.ToString()
            }).ToList();

            //return repositorio
            //    .ListarTurmas()
            //    .Select(x => new SelectListItem
            //    {
            //        Text = x.Descricao,
            //        Value = x.Id.ToString()
            //    }).ToList();
        }

        [Autenticacao(Roles = "_ALUNO_")]
        public ActionResult InscricaoAsync()
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


            var listaDeTurmas = _turmaService.ListarTurmas();
            //for (int i = 0; i < listaDeTurmas.Count; i++)
            //{
            //    turmas.Add(new SelectListItem()
            //    {
            //        Text = listaDeTurmas[i].Descricao,
            //        Value = listaDeTurmas[i].Id.ToString()
            //    });
            //}

            turmas = ListarTurmas();

            ViewBag.Turmas = turmas;

            return View();
        }
        
        [Autenticacao(Roles = "_ALUNO_")]
        [HttpPost]
        public ActionResult Inscricao(InscricaoViewModel inscricaoViewModel)
        {
            UsuarioService usuarioService = new UsuarioService();
            Aluno alunoAtual = (Aluno)Session["TreinamentoTurmaUsuarioAtual"];
           
            inscricaoViewModel.AlunoId = alunoAtual.Id;
            inscricaoViewModel.InscritoEm = DateTime.Now;
            //inscricaoViewModel.AlunoId = usuarioService.BuscarUsuarioPeloCodigo(alunoAtual.Codigo).Id;

            if (_turmaService.BuscarInscricao(inscricaoViewModel.AlunoId, inscricaoViewModel.TurmaId).Sucesso == null)
            {
                _turmaService.CadastrarInscricao(Mapper.Map<Inscricao>(inscricaoViewModel));
            }
            else
            {
                ModelState.AddModelError("", "Este aluno já está inscrito nesta turma");
            }

            ViewBag.Turmas = ListarTurmas();

            return View();
        }
    }
}



//if (!ModelState.IsValid)
//{
//    return View(turma);
//}