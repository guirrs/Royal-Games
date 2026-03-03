using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public readonly RoyalGamesContext _context;
        public JogoRepository(RoyalGamesContext context) 
        { 
            _context = context;
        }
        public List<Jogo> Listar()
        {
            return _context.Jogo.ToList();
        }

        public Jogo ObterPorId(int id)
        {
            Jogo? jogo = _context.Jogo.Find(id);
            return jogo;
        }

        public byte[] ObterImagem(int id)
        {

        }

        public void Adicionar(Jogo jogoDto)
        {
            _context.Jogo.Add(jogoDto);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogoDto)
        {
            Jogo? jogo = _context.Jogo.Find(jogoDto.JogoID);

            if(jogo == null)
            {
                return;
            }

            jogo.Nome = jogoDto.Nome;
            jogo.Descricao = jogoDto.Descricao;
            jogo.Preco = jogoDto.Preco;
            jogo.Imagem = jogoDto.Imagem;
            jogo.DataLancamento = jogoDto.DataLancamento;

            jogo.ClassificacaoIndicativaID = jogoDto.ClassificacaoIndicativaID;
            jogo.Plataforma = jogoDto.Plataforma;
            jogo.Genero = jogoDto.Genero;

            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Jogo? jogo = _context.Jogo.Find(id);

            if(jogo == null)
            {
                return;
            }

            _context.Jogo.Remove(jogo);
            _context.SaveChanges();
        }
    }
}
