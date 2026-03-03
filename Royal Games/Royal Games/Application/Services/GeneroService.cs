using Royal_Games.Domains;
using Royal_Games.DTO.GeneroDto;
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

        public List<LerPlataformaDto> Listar()
        {
            List<Genero> generos = _repository.Listar();
            List<LerPlataformaDto> generoDTOs = generos.Select(genero => new LerPlataformaDto
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            }).ToList();

            return generoDTOs;
        }

        public LerPlataformaDto ObterPorID(int id)
        {
            Genero genero = _repository.BuscarporID(id);
            if (genero == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            LerPlataformaDto generoDTO = new LerPlataformaDto
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            };

            return generoDTO;
        }

        private static void ValidarGenero(LerPlataformaDto genero)
        {
            if (string.IsNullOrEmpty(genero.Nome))
            {
                throw new DomainException("O nome do genero é obrigatório.");
            }
        }

        private void ValidarGeneroExistente(string nome, int? id = null)
        {
            bool existe = id == null
                ? _repository.GeneroExiste(nome)
                : _repository.GeneroExiste(nome, id.Value);

            if (existe)
            {
                throw new DomainException("Genero já existente");
            }
        }

        public void Cadastrar(LerPlataformaDto genero)
        {
            ValidarGenero(genero);
            ValidarGeneroExistente(genero.Nome);

            Genero novoGenero = new Genero
            {
                Nome = genero.Nome
            };

            _repository.Cadastrar(novoGenero);
        }

        public void Atualizar(int id, LerPlataformaDto genero)
        {
            ValidarGenero(genero);

            Genero generoBanco = _repository.BuscarporID(id);

            if (generoBanco == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            ValidarGeneroExistente(genero.Nome, id);

            generoBanco.Nome = genero.Nome;

            _repository.atualizar(generoBanco);
        }

        public void Remover(int id)
        {
            Genero generoBanco = _repository.BuscarporID(id);

            if (generoBanco == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            _repository.Deletar(id);
        }
    }
}