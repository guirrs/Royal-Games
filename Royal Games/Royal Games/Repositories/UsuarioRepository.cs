using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RoyalGamesContext _context;

        public UsuarioRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public Usuario ObterPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public Usuario ObterPorEmail(string email)
        {
            return _context.Usuario.FirstOrDefault(usuarioAux => usuarioAux.Email == email);
        }

        public bool EmailExiste(string email)
        {
            return _context.Usuario.Any(usuarioAux  => usuarioAux.Email == email);
        }

        public void Adicionar (Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            Usuario? usuarioBanco = _context.Usuario.Find(usuario.UsuarioID);

            if (usuarioBanco == null)
                return;

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Email = usuario.Email; 
            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.StatusUsuario = usuario.StatusUsuario;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
        Usuario? usuario = _context.Usuario.Find(id);

            if (usuario == null) return;

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
