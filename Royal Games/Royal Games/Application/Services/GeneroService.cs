using Royal_Games.Domains;
using Royal_Games.DTO.GeneroDTo;
using Royal_Games.Exceptions;
using Royal_Games.Interface;

namespace Royal_Games.Application.Services
{
    public class GeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public List<generoDTO> Listar()
        {
            List<Genero> generos = _repository.Listar();
            List<generoDTO> generoDTO = generos.Select(generoBanco => new LerGeneroDTO )
            .ToList();
        }

        private static void ValidarGenero(generoDTO genero)
        {
            if (string .IsNullOrEmpty(genero.Nome))
            {
                throw new DomainException("O nome do genero é obrigatório.");
            }
        }

        public void Cadastrar(generoDTO genero)
        {
            ValidarGenero(genero);

            if(_repository.GeneroExistente(genero.Nome)

           
           




        }





    }
}
