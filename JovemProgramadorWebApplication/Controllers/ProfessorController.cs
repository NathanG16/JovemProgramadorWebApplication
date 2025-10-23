using JovemProgramadorWebApplication.Data.Repositorio;
using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;
using Microsoft.AspNetCore.Mvc;


namespace JovemProgramadorWebApplication.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        public ProfessorController(IProfessorRepositorio professorRepositorio)
        {
            _professorRepositorio = professorRepositorio;
        }
        public IActionResult Index(string buscar)
        {
            var listaProfessores = _professorRepositorio.BuscarProfessor();
            if(!string.IsNullOrEmpty(buscar))
            {
                listaProfessores = listaProfessores
                                       .Where(p => p.NomeCompleto!.Contains(buscar, StringComparison.OrdinalIgnoreCase))
                                       .ToList();
                return View(listaProfessores);
            }
            return View(listaProfessores);
        }
        public IActionResult Adicionar()
        {
            return View();
        }
        public IActionResult CadastrarProfessor(Professor professor)
        {
            try
            {
                _professorRepositorio.CadastrarProfessor(professor);
                TempData["MensagemSucesso"] = "Professor cadastrado com sucesso!";
                return RedirectToAction("Index", "Professor");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar professor: " + ex.Message;
                return RedirectToAction("Index", "Professor");
            }
        }
        public IActionResult Excluir(Professor professor)
        {
            try
            {
                _professorRepositorio.ExcluirProfessor(professor);
                TempData["MensagemSucesso"] = "Professor excluído com sucesso!";
                return RedirectToAction("Index", "Professor");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao excluir Professor: " + ex.Message;
                return RedirectToAction("Index", "Professor");
            }
        }
        public IActionResult Editar(int id)
        {
            Professor professor = _professorRepositorio.BuscarProfessorPorId(id);

            if (professor == null)
            {
                TempData["MensagemErro"] = "professor não encontrado para edição.";
                return RedirectToAction("Index");
            }
            return View("Editar", professor);
        }
        public IActionResult EditarProfessor(Professor professor)
        {
            try
            {
                _professorRepositorio.EditarProfessor(professor);
                TempData["MensagemSucesso"] = "Professor editado com sucesso!";
                return RedirectToAction("Index", "Professor");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao editar Professor: " + ex.Message;
                return RedirectToAction("Index", "Professor");
            }
        }
    }
}
