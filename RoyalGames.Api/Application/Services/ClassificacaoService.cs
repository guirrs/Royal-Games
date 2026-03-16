using Royal_Games.Domains;
using Royal_Games.DTOs.ClassificacaoDto;
using Royal_Games.Exceptions;
using Royal_Games.Interface;

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
            return new LerClassificacaoDto
            {
                Id = classificacao.ClassificacaoIndicativaID,
                Faixa = classificacao.Faixa
            };
        }

        public List<LerClassificacaoDto> Listar()
        {
            List<ClassificacaoIndicativa> classificacaoBanco = _repository.Listar();

            return classificacaoBanco
                .Select(c => LerDto(c))
                .ToList();
        }

        public LerClassificacaoDto ObterPorId(int id)
        {
            ClassificacaoIndicativa? classificacao = _repository.ObterPorId(id);

            if (classificacao == null)
            {
                throw new DomainException("Classificação inexistente");
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

            if (classificacao == null)
            {
                throw new DomainException("Classificação inexistente");
            }

            classificacao.Faixa = classificacaoDto.Faixa;

            _repository.Atualizar(classificacao);

            return LerDto(classificacao);
        }

        public LerClassificacaoDto Remover(int id)
        {
            ClassificacaoIndicativa? classificacao = _repository.ObterPorId(id);

            if (classificacao == null)
            {
                throw new DomainException("Classificação inexistente");
            }

            _repository.Remover(classificacao);

            return LerDto(classificacao);
        }
    }
}
