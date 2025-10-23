using JovemProgramadorWebApplication.Data.Repositorio.Interfaces;
using JovemProgramadorWebApplication.Models;


namespace JovemProgramadorWebApplication.Data.Repositorio   
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly BancoContexto _bancoContexto;

        public UsuarioRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _bancoContexto.Usuario.Add(usuario);
            _bancoContexto.SaveChanges();
        }
        public Usuario ValidarUsuario(Usuario usuario)
        {
            return _bancoContexto.Usuario.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha);
        }
    }
}
