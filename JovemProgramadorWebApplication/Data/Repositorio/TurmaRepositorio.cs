using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;

namespace JovemProgramadorWebApplication.Data.Repositorio
{
    public class TurmaRepositorio : ITurmaRepositorio
    {

        private readonly BancoContexto _bancoContexto;

        public TurmaRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }
        public List<Turma> BuscarTurma()
        {
            return _bancoContexto.Turma.ToList();
        }
    }
}
