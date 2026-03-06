using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface ILogJogoRepository
    {
        public List<Log_AlteracaoJogo> Listar();
        public List<Log_AlteracaoJogo> ListarPorJogo(int id);
        public bool VerificarJogo(int id);
    }
}