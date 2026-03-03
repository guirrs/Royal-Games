using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class ClassificacaoRepository : IClassificacaoRepository
    {
        private readonly RoyalGamesContext _context;

        public ClassificacaoRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<ClassificacaoIndicativa> Listar()
        {
            return _context.ClassificacaoIndicativa.ToList();
        }

        public ClassificacaoIndicativa ObterPorId(int id)
        {
            return _context.ClassificacaoIndicativa.Find(id);
        }

        public void Adicionar(ClassificacaoIndicativa classificacao)
        {
            _context.ClassificacaoIndicativa.Add(classificacao);
            _context.SaveChanges();
        }
        public void Remover(ClassificacaoIndicativa classificacao)
        {
            _context.ClassificacaoIndicativa.Remove(classificacao);
            _context.SaveChanges();
        }

        public void Atualizar(ClassificacaoIndicativa classificacao)
        {
            ClassificacaoIndicativa? classificacaoBanco = _context.ClassificacaoIndicativa.Find
                (classificacao.ClassificacaoIndicativaID);

            if(classificacaoBanco == null)
            {
                return;
            }

            classificacaoBanco.Faixa = classificacao.Faixa;

            _context.SaveChanges ();
        }
    }
}
