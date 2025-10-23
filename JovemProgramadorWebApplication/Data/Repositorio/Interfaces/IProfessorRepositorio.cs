using JovemProgramadorWebApplication.Models;

namespace JovemProgramadorWebApplication.Data.Repositorio.Interfaces
{
    public interface IProfessorRepositorio
    {
        List<Professor> BuscarProfessor();
        public void CadastrarProfessor(Professor professor);
        public void ExcluirProfessor(Professor professor);
        public Professor BuscarProfessorPorId(int id);
        public void EditarProfessor(Professor professor);
    }
}
