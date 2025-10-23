using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JovemProgramadorWebApplication.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index(string buscar)
        {
            var listaAlunos = _alunoRepositorio.BuscarAluno();
            if (!string.IsNullOrEmpty(buscar))
            {
                listaAlunos = listaAlunos
                                   .Where(a => a.Nome!.Contains(buscar, StringComparison.OrdinalIgnoreCase))
                                   .ToList();
                return View(listaAlunos);
            }
            else
            { 
            return View(listaAlunos);
            }
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult CadastrarAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.CadastrarAluno(aluno);
                TempData["MensagemSucesso"] = "Aluno cadastrado com sucesso!";
                return RedirectToAction("Index", "Aluno");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar aluno: " + ex.Message;
                return RedirectToAction("Cadastro", "Aluno");
            }
        }
        public IActionResult Excluir(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.ExcluirAluno(aluno);
                TempData["MensagemSucesso"] = "Aluno excluído com sucesso!";
                return RedirectToAction("Index", "Aluno");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao excluir aluno: " + ex.Message;
                return RedirectToAction("Index", "Aluno");
            }
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            Aluno aluno = _alunoRepositorio.BuscarAlunoPorId(id);

            if (aluno == null)
            {
                TempData["MensagemErro"] = "Aluno não encontrado para edição.";
                return RedirectToAction("Index");
            }
            return View("Editar",aluno);
        }
        [HttpPost]
        public IActionResult EditarAluno(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.EditarAluno(aluno);
                TempData["MensagemSucesso"] = "Aluno editado com sucesso!";
                return RedirectToAction("Index", "Aluno");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao editar aluno: " + ex.Message;
                return RedirectToAction("Index", "Aluno");
            }
        }   
    }
}       