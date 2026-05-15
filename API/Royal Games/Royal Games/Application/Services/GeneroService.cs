using Royal_Games.Domains;
using Royal_Games.Exceptions;
using Royal_Games.Interface;
using Royal_Games.DTO.GeneroDto;
using System.Collections.Generic;
using System.Linq;
using Royal_Games.DTO.GeneroDto;

namespace Royal_Games.Application.Services
{
    public class GeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public List<LerGeneroDto> Listar()
        {
            List<Genero> generos = _repository.Listar();
            return generos.Select(g => new LerGeneroDto
            {
                GeneroID = g.GeneroID,
                Nome = g.Nome
            }).ToList();
        }

        public LerGeneroDto ObterPorID(int id)
        {
            Genero genero = _repository.BuscarporID(id);
            if (genero == null)
            {
                throw new DomainException("Gênero não encontrado");
            }

            return new LerGeneroDto
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            };
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("O nome do gênero é obrigatório.");
            }
        }

        private void ValidarGeneroExistente(string nome, int? id = null)
        {
            bool existe = id == null
                ? _repository.GeneroExiste(nome)
                : _repository.GeneroExiste(nome, id.Value);

            if (existe)
            {
                throw new DomainException("Gênero já existente");
            }
        }

        public void Cadastrar(CriarGeneroDTO generoDTO)
        {
            ValidarNome(generoDTO.Nome);
            ValidarGeneroExistente(generoDTO.Nome);

            Genero novoGenero = new Genero
            {
                Nome = generoDTO.Nome
            };

            _repository.Cadastrar(novoGenero);
        }

        public void Atualizar(int id, LerGeneroDto generoDTO)
        {
            ValidarNome(generoDTO.Nome);

            Genero generoBanco = _repository.BuscarporID(id);
            if (generoBanco == null)
            {
                throw new DomainException("Gênero não encontrado");
            }

            ValidarGeneroExistente(generoDTO.Nome, id);

            generoBanco.Nome = generoDTO.Nome;
            _repository.Atualizar(generoBanco);
        }

        public void Remover(int id)
        {
            Genero generoBanco = _repository.BuscarporID(id);
            if (generoBanco == null)
            {
                throw new DomainException("Gênero não encontrado");
            }

            _repository.Deletar(id);
        }
    }
}