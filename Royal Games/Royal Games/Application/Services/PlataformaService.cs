<<<<<<< HEAD
﻿using Royal_Games.Domains;
using Royal_Games.DTO.PlataformaDTo;
using Royal_Games.DTOs.PlataformaDto;
using Royal_Games.Exceptions;
using Royal_Games.Interface;
=======
﻿using Royal_Games.Interface;
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a

namespace Royal_Games.Application.Services
{
    public class PlataformaService
    {
<<<<<<< HEAD

=======
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
        private readonly IPlataformaRepository _repository;

        public PlataformaService(IPlataformaRepository repository)
        {
            _repository = repository;
        }

<<<<<<< HEAD
        public List<LerPlataformaDTO> Listar()
        {
            List<Plataforma> plataformas = _repository.Listar();
            List<LerPlataformaDTO> plataformaDTOs = plataformas.Select(plataforma => new LerPlataformaDTO
            {
                PlataformaID = plataforma.PlataformaID,
                Nome = plataforma.Nome
            }).ToList();

            return plataformaDTOs;
        }

        public LerPlataformaDTO ObterPorID(int id)
        {
            Plataforma Plataforma = _repository.BuscarporID(id);
            if (Plataforma == null)
            {
                throw new DomainException("plataforma não encontrada");
            }

            LerPlataformaDTO plataformaDTO = new LerPlataformaDTO
            {
                PlataformaID = Plataforma.PlataformaID,
                Nome = Plataforma.Nome
            };

            return plataformaDTO;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("O nome do gênero é obrigatório.");
            }
        }

        private void ValidarPlataformaExistente(string nome, int? id = null)
        {
            bool existe = id == null
                ? _repository.PlataformaExiste(nome)
                : _repository.PlataformaExiste(nome, id.Value);

            if (existe)
            {
                throw new DomainException("Plataforma já existente");
            }
        }

        public void Cadastrar(CriarPlataformaDTO PlataformaDto)
        {
            ValidarNome(PlataformaDto.Nome);
            ValidarPlataformaExistente(PlataformaDto.Nome);

            Plataforma novaPlataforma = new Plataforma
            {
                Nome = PlataformaDto.Nome
            };

            _repository.Cadastrar(novaPlataforma);
        }

        public void Atualizar(int id, LerPlataformaDTO PlataformaDto)
        {
            ValidarNome(PlataformaDto.Nome);

            Plataforma PlataformaBanco = _repository.BuscarporID(id);

            if (PlataformaBanco == null)
            {
                throw new DomainException("Plataforma não encontrada");
            }

            ValidarPlataformaExistente(PlataformaDto.Nome, id);

            PlataformaBanco.Nome = PlataformaDto.Nome;

            _repository.Atualizar(PlataformaBanco);
        }

        public void Remover(int id)
        {
            Plataforma PlataformaBanco = _repository.BuscarporID(id);

            if (PlataformaBanco == null)
            {
                throw new DomainException("Plataforma não encontrada");
            }

            _repository.Deletar(id);
        }
    }
}

=======




    }
}
>>>>>>> 0e2b3aef78f5fb8108e93690daa27be99f8df15a
