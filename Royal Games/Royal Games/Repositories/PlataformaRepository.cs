using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interface;

namespace Royal_Games.Repositories
{
<<<<<<< HEAD
    public class PlataformaRepository : IPlataformaRepository
=======
    public class PlataformaRepository: IPlataformaRepository
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
    {
        private readonly RoyalGamesContext _context;

        public PlataformaRepository(RoyalGamesContext context)
        {
            _context = context;
<<<<<<< HEAD

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



=======
        }

>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
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

<<<<<<< HEAD
            if (plataformaBanco == null)
=======
            if(plataformaBanco == null)
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
            {
                return;
            }

            _context.Plataforma.Remove(plataformaBanco);
            _context.SaveChanges();
        }









    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
