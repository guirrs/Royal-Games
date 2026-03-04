using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IPlataformaRepository
    {
        List<Plataforma> Listar();
        Plataforma BuscarporID(int id);

<<<<<<< HEAD
        bool PlataformaExiste(string nome, int? PlataformaID = null);
=======
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
        void Cadastrar(Plataforma plataforma);
        void Atualizar(Plataforma plataforma);
        void Deletar(int id);

    }
}
