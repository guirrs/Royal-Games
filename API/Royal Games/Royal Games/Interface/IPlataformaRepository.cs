using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IPlataformaRepository
    {
        List<Plataforma> Listar();
        Plataforma BuscarporID(int id);
        
        bool PlataformaExiste(string nome, int? PlataformaID = null);
        void Cadastrar(Plataforma plataforma);
        void Atualizar(Plataforma plataforma);
        void Deletar(int id);

    }
}
