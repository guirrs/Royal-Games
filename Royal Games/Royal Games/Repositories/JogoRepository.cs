using Microsoft.EntityFrameworkCore;
using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly RoyalGamesContext _context;

        public JogoRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Jogo> Listar()
        {
            return _context.Jogo
                .Include(j => j.Genero)
                .Include(j => j.Plataforma)
                .Include(j => j.ClassificacaoIndicativa)
                .ToList();
        }

        public Jogo? ObterPorId(int id)
        {
            return _context.Jogo
                .Include(j => j.Genero)
                .Include(j => j.Plataforma)
                .Include(j => j.ClassificacaoIndicativa)
                .FirstOrDefault(j => j.JogoID == id);
        }

        public byte[] ObterImagem(int id)
        {
            return _context.Jogo
                .Where(j => j.JogoID == id)
                .Select(j => j.Imagem)
                .FirstOrDefault();
        }

        public List<Jogo> ObterPorPlataforma(string plataformaNome)
        {
            List<Jogo> jogos = _context.Jogo.Where(jogoAux => jogoAux.Plataforma.Any(j => j.Nome == plataformaNome)).ToList();

            return jogos;
        }

        public List<Jogo> ObterPorGenero(string generoNome)
        {
            List<Jogo> jogos = _context.Jogo.Where(jogoAux => jogoAux.Genero.Any(j => j.Nome == generoNome)).ToList();

            return jogos;
        }

        public void Adicionar(Jogo jogo, List<int> generosId, List<int> plataformaId, int classificacaoId)
        {
            var generos = _context.Genero.Where(g => generosId.Contains(g.GeneroID)).ToList();
            var plataformas = _context.Plataforma.Where(p => plataformaId.Contains(p.PlataformaID)).ToList();

            jogo.Genero = generos;
            jogo.Plataforma = plataformas;
            jogo.ClassificacaoIndicativaID = classificacaoId;

            _context.Jogo.Add(jogo);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogo, List<int> generosId, List<int> plataformaId, int classificacaoId)
        {
            var jogoExistente = _context.Jogo
                .Include(j => j.Genero)
                .Include(j => j.Plataforma)
                .FirstOrDefault(j => j.JogoID == jogo.JogoID);

            if (jogoExistente == null)
                return;

            jogoExistente.Nome = jogo.Nome;
            jogoExistente.Descricao = jogo.Descricao;
            jogoExistente.Preco = jogo.Preco;
            jogoExistente.Imagem = jogo.Imagem;
            jogoExistente.DataLancamento = jogo.DataLancamento;
            jogoExistente.StatusJogo = jogo.StatusJogo;
            jogoExistente.ClassificacaoIndicativaID = classificacaoId;

            var generos = _context.Genero.Where(g => generosId.Contains(g.GeneroID)).ToList();
            jogoExistente.Genero.Clear();
            foreach (var genero in generos)
                jogoExistente.Genero.Add(genero);

            var plataformas = _context.Plataforma.Where(p => plataformaId.Contains(p.PlataformaID)).ToList();
            jogoExistente.Plataforma.Clear();
            foreach (var plataforma in plataformas)
                jogoExistente.Plataforma.Add(plataforma);

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            var jogo = _context.Jogo.Find(id);
            if (jogo == null)
                return;

            _context.Jogo.Remove(jogo);
            _context.SaveChanges();
        }

        public bool NomeExiste(string nome, int? id = null)
        {
            if (id.HasValue)
            {
                return _context.Jogo.Any(j => j.Nome == nome && j.JogoID != id.Value);
            }
            return _context.Jogo.Any(j => j.Nome == nome);
        }
    }
}