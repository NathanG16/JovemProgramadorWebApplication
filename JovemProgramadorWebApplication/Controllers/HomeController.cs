using JovemProgramadorWebApplication.Data.Repositorio;
using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JovemProgramadorWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; IAlunoRepositorio _alunoRepositorio; ITurmaRepositorio _turmaRepopsitorio;

        public HomeController(ILogger<HomeController> logger, IAlunoRepositorio alunoRepositorio, ITurmaRepositorio turmaRepositorio)
        {
            _logger = logger;
            _alunoRepositorio = alunoRepositorio;
            _turmaRepopsitorio = turmaRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Relatorio()
        {
            var alunos = _alunoRepositorio.BuscarAluno();
            var turmas = _turmaRepopsitorio.BuscarTurma();

            List<RelatorioViewModel> relatorioViewModels = alunos
                .Select(x => new RelatorioViewModel
                {
                    Aluno = x,
                    Turma = turmas.FirstOrDefault( y => y.Id == x.Id_Turma)
                }).ToList();
            return View(relatorioViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
