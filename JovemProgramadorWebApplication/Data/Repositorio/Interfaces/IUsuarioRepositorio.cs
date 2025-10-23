using JovemProgramadorWebApplication.Models;

namespace JovemProgramadorWebApplication.Data.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        public void CadastrarUsuario(Usuario usuario);

        public Usuario ValidarUsuario(Usuario usuario);
    }
}
