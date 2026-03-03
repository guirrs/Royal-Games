using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IUsuarioRepository 
    {
        public List<Usuario> Listar();
        public Usuario ObterPorId (int id);
        public Usuario ObterPorEmail (string email);
        public bool EmailExiste (string email);

        public void Adicionar (Usuario usuario);
        public void Remover (int  id);
        public void Atualizar (Usuario usuario);
    }
}
