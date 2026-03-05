using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IGeneroRepository
    {
        List<Genero> Listar();
        Genero BuscarporID(int id);
        
        bool GeneroExiste(string nome, int? GeneroID = null );
        void Cadastrar(Genero genero);
        void Atualizar(Genero genero);
        void Deletar(int id);

       
    }
}
