using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IGeneroRepository
    {
        List<Genero> Listar();
        Genero BuscarporID(int id);

        void Cadastrar(Genero genero);
        void atualizar(Genero genero);
        void Deletar(int id);
         
    }
}
