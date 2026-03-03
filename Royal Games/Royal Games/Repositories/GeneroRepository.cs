using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly RoyalGamesContext _context;

        public GeneroRepository(RoyalGamesContext context)
        {
            _context = context;
        }

        public List<Genero> Listar()
        {
            return _context.Genero.ToList();
        }

        public Genero BuscarporID(int id)
        {
            Genero? genero = _context.Genero.FirstOrDefault(g => g.GeneroID == id);

            return genero;
        }

        public void Cadastrar(Genero genero)
        {
            _context.Genero.Add(genero);
            _context.SaveChanges();
        }

        public void atualizar(Genero genero)
        {
            Genero? generoBanco = _context.Genero.FirstOrDefault(g => g.GeneroID == genero.GeneroID);

            if (generoBanco == null)
            {
                return;
            }

            _context.Genero.Update(genero);
            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            Genero? generoBanco = _context.Genero.FirstOrDefault(g => g.GeneroID == id);

            if (generoBanco == null)
            {
                return;
            }

            _context.Genero.Remove(generoBanco);
            _context.SaveChanges();
        }







    }
}