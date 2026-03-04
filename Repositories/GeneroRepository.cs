using Royal_Games.Domains;
using Royal_Games.DTO.GeneroDTO;
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

        public List<LerGeneroDTO> Listar()
        {
            List<Genero> generos = _repository.Listar();
            List<LerGeneroDTO> generoDTOs = generos.Select(genero => new LerGeneroDTO
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            }).ToList();

            return generoDTOs;
        }

        public LerGeneroDTO ObterPorID(int id)
        {
            Genero genero = _repository.BuscarPorID(id);
            if (genero == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            LerGeneroDTO generoDTO = new LerGeneroDTO
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            };

            return generoDTO;
        }

        private static void ValidarGenero(GeneroDTO genero)
        {
            if (string.IsNullOrEmpty(genero.Nome))
            {
                throw new DomainException("O nome do genero é obrigatório.");
            }
        }

        private void ValidarGeneroExistente(string nome, int? id = null)
        {
            bool existe = id == null
                ? _repository.GeneroExistente(nome)
                : _repository.GeneroExistente(nome, id.Value);

            if (existe)
            {
                throw new DomainException("Genero já existente");
            }
        }

        public void Cadastrar(GeneroDTO genero)
        {
            ValidarGenero(genero);
            ValidarGeneroExistente(genero.Nome);

            Genero novoGenero = new Genero
            {
                Nome = genero.Nome
            };

            _repository.Cadastrar(novoGenero);
        }

        public void Atualizar(int id, GeneroDTO genero)
        {
            ValidarGenero(genero);

            Genero generoBanco = _repository.BuscarPorID(id);

            if (generoBanco == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            ValidarGeneroExistente(genero.Nome, id);

            generoBanco.Nome = genero.Nome;

            _repository.Atualizar(generoBanco);
        }

        public void Remover(int id)
        {
            Genero generoBanco = _repository.BuscarPorID(id);

            if (generoBanco == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            _repository.Deletar(id);
        }
    }
}
