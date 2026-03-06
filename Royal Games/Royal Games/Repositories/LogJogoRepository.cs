using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class LogJogoRepository : ILogJogoRepository
    {
        private readonly RoyalGamesContext _context;

        public LogJogoRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Log_AlteracaoJogo> Listar()
        {
            return _context.Log_AlteracaoJogo.OrderByDescending(log => log.DataAlteracao).ToList();
        }

        public List<Log_AlteracaoJogo> ListarPorJogo(int id)
        {
            return _context.Log_AlteracaoJogo.Where(log => log.JogoID == id).OrderByDescending(log => log.DataAlteracao).ToList();
        }

        public bool VerificarJogo(int id)
        {
            Jogo? jogo = _context.Jogo.Find(id);

            if (jogo == null)
            {
                return false;
            }
            return true;
        }
    }
}