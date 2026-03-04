using Royal_Games.Domains;
<<<<<<< HEAD
using Royal_Games.DTOs.GeneroDto;
=======
using Royal_Games.DTO.GeneroDTo;
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
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

<<<<<<< HEAD
        public List<LerGeneroDTO> Listar()
        {
            List<Genero> generos = _repository.Listar();
            List<LerGeneroDTO> GeneroDTOs = generos.Select(genero => new LerGeneroDTO
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            }).ToList();

            return GeneroDTOs;
        }

        public LerGeneroDTO ObterPorID(int id)
        {
            Genero genero = _repository.BuscarporID(id);
            if (genero == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            LerGeneroDTO GeneroDTO = new LerGeneroDTO
=======
        public List<generoDTO> Listar()
        {
            List<Genero> generos = _repository.Listar();
            List<LerGeneroDTO> generoDTO = generos.Select(genero => new LerGeneroDTO
            {

                GeneroID = genero.GeneroID,
                Nome = genero.Nome

            }).ToList();

            return generoDTO;
        }

        public LerGeneroDTO ObterporID(int id)
        {
            Genero genero = _repository.BuscarporID(id);
            if(genero == null)
            {
                throw new DomainException("Genero não encontrado")
            }

            LerGeneroDTO generoDTO = new LerGeneroDTO
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
            {
                GeneroID = genero.GeneroID,
                Nome = genero.Nome
            };

<<<<<<< HEAD
            return GeneroDTO;
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
                throw new DomainException("Genero já existente");
            }
        }

        public void Cadastrar(CriarGeneroDTO GeneroDTO)
        {
            ValidarNome(GeneroDTO.Nome);
            ValidarGeneroExistente(GeneroDTO.Nome);

            Genero novoGenero = new Genero
            {
                Nome = GeneroDTO.Nome
            };

            _repository.Cadastrar(novoGenero);
        }

        public void Atualizar(int id, LerGeneroDTO GeneroDto)
        {
            ValidarNome(GeneroDto.Nome);

            Genero generoBanco = _repository.BuscarporID(id);

            if (generoBanco == null)
            {
                throw new DomainException("Genero não encontrado");
            }

            ValidarGeneroExistente(GeneroDto.Nome, id);

            generoBanco.Nome = GeneroDto.Nome;

            _repository.atualizar(generoBanco);
=======
            return generoDTO;
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

            if (_repository.GeneroExistente(CriarGeneroDTO.Nome))
            {
                throw new DomainException("Genero ja existente");
            }


                Genero genero = new Genero
                {
                    Nome = CriarGeneroDTO.Nome
                };

                _repository.Cadastrar(Genero);
            }

           public void Atualizar(int id, generoDTO genero)
        {
            ValidarGenero(CriarGeneroDTO.Nome);

            Genero generoBanco = _repository.BuscarporID(id);

            if(generoBanco == null)
            {

                throw new DomainException("Genero nao encontrado");
            
            }

            if(_repository.GeneroExistente(CriarGeneroDTO.Nome, GeneroID: id))
            {
                throw new DomainException("Ja existe um genero com esse nome");
            }

            GeneroBanco.Nome = CriarGeneroDTO.Nome;
            _repository.atualizar(generoBanco);

>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
        }

        public void Remover(int id)
        {
<<<<<<< HEAD
            Genero generoBanco = _repository.BuscarporID(id);

            if (generoBanco == null)
            {
                throw new DomainException("Genero não encontrado");
=======
            Categoria categoriaBanco = _repository.BuscarporID(id);

            if (categoriaBanco == null)
            {
                throw new DomainException("Categoria nao encontrada");
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
            }

            _repository.Deletar(id);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
