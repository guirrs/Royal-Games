using Royal_Games.Application.Conversoes;
using Royal_Games.Domains;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.Exceptions;
using Royal_Games.Interface;

namespace Royal_Games.Application.Services
{
    public class JogoService
    {
        private readonly IJogoRepository _repository;

        public JogoService(IJogoRepository repository)
        {
            _repository = repository;
        }

        public LerJogoDto LerDto(Jogo jogo)
        {
            return new LerJogoDto
            {
                Nome = jogo.Nome,
                Descricao = jogo.Descricao,
                Preco = jogo.Preco,
                StatusJogo = jogo.StatusJogo,

                GenerosId = jogo.Genero?.Select(g => g.GeneroID).ToList(),
                Generos = jogo.Genero?.Select(g => g.Nome).ToList(),

                PlataformaId = jogo.Plataforma?.Select(p => p.PlataformaID).ToList(),
                Plataforma = jogo.Plataforma?.Select(p => p.Nome).ToList(),

                ClassificacaoId = jogo.ClassificacaoIndicativaID,
            };
        }

        public List<LerJogoDto> Listar()
        {
            List<Jogo> jogos = _repository.Listar();
            return jogos.Select(j => LerDto(j)).ToList();
        }

        public LerJogoDto ObterPorId(int id)
        {
            Jogo? jogo = _repository.ObterPorId(id);

            if (jogo == null)
            {
                throw new DomainException("Esse jogo não existe");
            }

            return LerDto(jogo);
        }

        public byte[] ObterImagem(int id)
        {
            var imagem = _repository.ObterImagem(id);

            if (imagem == null || imagem.Length == 0)
            {
                throw new DomainException("Imagem não encontrada.");
            }

            return imagem;
        }

        public static void ValidarCadastro(CriarJogoDto jogoDto)
        {
            if (string.IsNullOrWhiteSpace(jogoDto.Nome))
                throw new DomainException("Nome é obrigatório.");

            if (jogoDto.Preco < 0)
                throw new DomainException("Preço deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(jogoDto.Descricao))
                throw new DomainException("Descrição é obrigatória.");

            if (jogoDto.Imagem == null || jogoDto.Imagem.Length == 0)
                throw new DomainException("Imagem é obrigatória.");

            if (jogoDto.GenerosId == null || !jogoDto.GenerosId.Any())
                throw new DomainException("Jogo deve ter ao menos um gênero.");

            if (jogoDto.PlataformaId == null || !jogoDto.PlataformaId.Any())
                throw new DomainException("Produto deve ter ao menos uma plataforma.");

            if (jogoDto.ClassificacaoId == null)
                throw new DomainException("Produto deve ter ao menos uma classificação.");
        }

        public List<LerJogoDto> ObterPorPlataforma (string plataforma)
        {
            List<Jogo> jogos = _repository.ObterPorPlataforma(plataforma);
            List<LerJogoDto> jogosDto = jogos.Select(jogoAux => LerDto(jogoAux)).ToList();

            return jogosDto;
        }

        public List<LerJogoDto> ObterPorGenero(string genero)
        {
            List<Jogo> jogos = _repository.ObterPorGenero(genero);
            List<LerJogoDto> jogosDto = jogos.Select(jogoAux => LerDto(jogoAux)).ToList();

            return jogosDto;
        }

        public LerJogoDto Adicionar(CriarJogoDto jogoDto, int usuarioId)
        {
            ValidarCadastro(jogoDto);

            Jogo jogo = new Jogo
            {
                Nome = jogoDto.Nome,
                Descricao = jogoDto.Descricao,
                Preco = jogoDto.Preco,
                Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem),
                StatusJogo = true,
                UsuarioID = usuarioId,
                ClassificacaoIndicativaID = jogoDto.ClassificacaoId
            };

            _repository.Adicionar(jogo, jogoDto.GenerosId, jogoDto.PlataformaId);

            return LerDto(jogo);
        }
        public void Remover(int id)
        {
            Jogo? jogo = _repository.ObterPorId(id);

            if (jogo == null)
                throw new DomainException("Jogo não existe");

            _repository.Remover(id);
        }

        public LerJogoDto Atualizar(AtualizarJogoDto jogoDto, int id)
        {
            Jogo? jogo = _repository.ObterPorId(id);

            if (jogo == null)
                throw new DomainException("Jogo não existe");

            if (_repository.NomeExiste(jogoDto.Nome, id))
                throw new DomainException("Já existe outro jogo com esse nome.");

            if (jogoDto.Preco < 0)
                throw new DomainException("Preço deve ser maior que zero.");

            if (jogoDto.PlataformaId == null || !jogoDto.PlataformaId.Any())
                throw new DomainException("Produto deve ter ao menos uma plataforma.");

            jogo.Nome = jogoDto.Nome;
            jogo.Preco = jogoDto.Preco;
            jogo.Descricao = jogoDto.Descricao;

            if (jogoDto.Imagem != null && jogoDto.Imagem.Length > 0)
            {
                jogo.Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem);
            }

            if (jogoDto.StatusJogo.HasValue)
            {
                jogo.StatusJogo = jogoDto.StatusJogo.Value;
            }

    _repository.Atualizar(jogo, jogoDto.GeneroId, jogoDto.PlataformaId);
            return LerDto(jogo);
        }
    }
}