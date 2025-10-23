using JovemProgramadorWebApplication.Data;
using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWebApplication.Data.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public ProfessorRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public List<Professor> BuscarProfessor()
        {
            return _bancoContexto.Professor.ToList();
        }
        public void CadastrarProfessor(Professor professor)
        {
            _bancoContexto.Professor.Add(professor);
            _bancoContexto.SaveChanges();
        }
        public void ExcluirProfessor(Professor professor)
        {
            _bancoContexto.Professor.Remove(professor);
            _bancoContexto.SaveChanges();
        }
        public Professor BuscarProfessorPorId(int id)
        {
            return _bancoContexto.Professor.FirstOrDefault(p => p.Id == id);
        }
        public void EditarProfessor(Professor professorAtualizado)
        {
            Professor professorExistente = _bancoContexto.Professor.Find(professorAtualizado.Id);
            if (professorExistente != null)
            {
                professorExistente.NomeCompleto = professorAtualizado.NomeCompleto;
                professorExistente.Disciplina = professorAtualizado.Disciplina;
                _bancoContexto.SaveChanges();
            }
            else
            {
                throw new Exception("Professor não encontrado para atualização.");
            }
        }
    }
}