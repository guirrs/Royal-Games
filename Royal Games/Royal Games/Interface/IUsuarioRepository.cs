using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IUsuarioRepository 
    {
        List<Usuario> Listar();
        Usuario ObterPorId (int id);
        Usuario ObterPorEmail (string email);
        bool EmailExiste (string email);

        void Adicionar (Usuario usuario);
        void Remover (int  id);
        void Atualizar (Usuario usuario);
    }
}
