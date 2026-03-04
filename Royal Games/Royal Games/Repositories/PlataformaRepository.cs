using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        private readonly RoyalGamesContext _context;

        public PlataformaRepository(RoyalGamesContext context)
        {
            _context = context;

        }

        public bool PlataformaExiste(string nome, int? plataformaId = null)
        {
            if (plataformaId == null)
            {
                return _context.Plataforma.Any(p => p.Nome == nome);
            }
            else
            {
                return _context.Plataforma.Any(p => p.Nome == nome && p.PlataformaID != plataformaId.Value);
            }
        }
        }

        public List<Plataforma> Listar()
        {
            return _context.Plataforma.ToList();
        }

        public Plataforma BuscarporID(int id)
        {
            Plataforma? plataforma = _context.Plataforma.FirstOrDefault(p => p.PlataformaID == id);

            return plataforma;
        }

        public void Cadastrar(Plataforma plataforma)
        {
            _context.Plataforma.Add(plataforma);
            _context.SaveChanges();

        }

        public void Atualizar(Plataforma plataforma)
        {

            Plataforma? plataformaBanco = _context.Plataforma.FirstOrDefault(p => p.PlataformaID == plataforma.PlataformaID);

            if (plataformaBanco == null)
            {
                return;
            }

            _context.Plataforma.Update(plataforma);
            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            Plataforma? plataformaBanco = _context.Plataforma.FirstOrDefault(p => p.PlataformaID == id);

            if (plataformaBanco == null)
            if(plataformaBanco == null)
            {
                return;
            }

            _context.Plataforma.Remove(plataformaBanco);
            _context.SaveChanges();
        }
    }
