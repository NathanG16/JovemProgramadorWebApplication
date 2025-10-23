using JovemProgramadorWebApplication.Models;

namespace JovemProgramadorWebApplication.Data.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        public void CadastrarAluno(Aluno aluno);
        public List<Aluno> BuscarAluno();
        public void ExcluirAluno(Aluno aluno);
        public Aluno BuscarAlunoPorId(int id);
        public void EditarAluno(Aluno aluno);
    }
}
