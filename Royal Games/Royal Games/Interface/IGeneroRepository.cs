using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IGeneroRepository
    {
        List<Genero> Listar();
        Genero BuscarporID(int id);
<<<<<<< HEAD
        
        bool GeneroExiste(string nome, int? GeneroID = null );
        void Cadastrar(Genero genero);
        void atualizar(Genero genero);
        void Deletar(int id);

=======

        void Cadastrar(Genero genero);
        void atualizar(Genero genero);
        void Deletar(int id);
         
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
    }
}
