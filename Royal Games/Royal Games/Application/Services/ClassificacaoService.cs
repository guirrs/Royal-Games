using Royal_Games.Domains;
using Royal_Games.DTOs.ClassificacaoDto;
using Royal_Games.Exceptions;
using Royal_Games.Interface;
using Royal_Games.Repositories;

namespace Royal_Games.Application.Services
{
    public class ClassificacaoService
    {
        private readonly IClassificacaoRepository _repository;

        public ClassificacaoService(IClassificacaoRepository repository)
        {
            _repository = repository;
        }

        public static LerClassificacaoDto LerDto(ClassificacaoIndicativa classificacao)
        {
            LerClassificacaoDto classificacaoDto = new LerClassificacaoDto
            {
                Id = classificacao.ClassificacaoIndicativaID,
                Faixa = classificacao.Faixa
            };

            return classificacaoDto;
        }

        public List<LerClassificacaoDto> Listar()
        {
            List<ClassificacaoIndicativa> classificacaoBanco = _repository.Listar();
            List<LerClassificacaoDto> classificacaoDto = classificacaoBanco.Select
                (classificacaoAux => LerDto(classificacaoAux)).ToList();
            return classificacaoDto;
        }

        public LerClassificacaoDto ObterPorId(int id)
        {
            ClassificacaoIndicativa? classificacao = _repository.ObterPorId(id);

            if(classificacao == null)
            {
                throw new DomainException("Classificação Inexistente");
            }

            return LerDto(classificacao);
        }
        public LerClassificacaoDto Adicionar(CriarClassificacaoDto classificacaoDto)
        {
            ClassificacaoIndicativa classificacao = new ClassificacaoIndicativa
            {
                Faixa = classificacaoDto.Faixa
            };

            _repository.Adicionar(classificacao);

            return LerDto(classificacao);
        }

        public LerClassificacaoDto Atualizar(CriarClassificacaoDto classificacaoDto, int id)
        {
            ClassificacaoIndicativa? classificacao = _repository.ObterPorId(id);

            if( classificacao == null)
            {
                throw new DomainException("Classificação inexistente");
            }

            _repository.Atualizar(classificacao);

            return LerDto(classificacao);
        }

        public LerClassificacaoDto Remover (int id)
        {
            ClassificacaoIndicativa? classificacao = _repository.ObterPorId (id);

            if (classificacao == null)
            {
                throw new DomainException("Classificação inexistente");
            }

            _repository.Remover(classificacao);
            return LerDto(classificacao);
        }
    }
}
