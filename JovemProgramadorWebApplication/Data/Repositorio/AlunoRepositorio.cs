using JovemProgramadorWebApplication.Data;
using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace JovemProgramadorWebApplication.Data.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public void CadastrarAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        public List<Aluno> BuscarAluno()
        {
            return _bancoContexto.Aluno.ToList();
        }
        public void ExcluirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }
        public Aluno BuscarAlunoPorId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(a => a.Id == id);
        }
        public void EditarAluno(Aluno alunoAtualizado)
        {
            Aluno alunoExistente = _bancoContexto.Aluno.Find(alunoAtualizado.Id);

            if (alunoExistente != null)
            {
                alunoExistente.Matricula = alunoAtualizado.Matricula;
                alunoExistente.Nome = alunoAtualizado.Nome;
                alunoExistente.Cpf = alunoAtualizado.Cpf;
                alunoExistente.Data_De_Nascimento = alunoAtualizado.Data_De_Nascimento;
                _bancoContexto.SaveChanges();
            }
            else
            {
                throw new Exception("Aluno não encontrado para atualização.");
            }
        }
    }
}