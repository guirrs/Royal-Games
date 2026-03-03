using Royal_Games.Application.Conversoes;
using Royal_Games.Domains;
using Royal_Games.DTOs.JogoDto;
using Royal_Games.Exceptions;
using Royal_Games.Repositories;

namespace Royal_Games.Application.Services
{
    public class JogoService
    {
        public readonly JogoRepository _repository;

        public JogoService(JogoRepository repository)
        {
            _repository = repository;
        }

        public LerJogoDto LerDto(Jogo jogo)
        {
            LerJogoDto jogoDto = new LerJogoDto
            {
                Nome = jogo.Nome,
                Descricao = jogo.Descricao,
                Preco = jogo.Preco,
                GenerosId = jogo.Genero.Select(jogoAux => jogoAux.GeneroID).ToList(),
                Generos = jogo.Genero.Select(jogoAux => jogoAux.Nome).ToList(),
                PlataformaId = jogo.Plataforma.Select(jogoAux => jogoAux.PlataformaID).ToList(),
                Plataforma = jogo.Plataforma.Select(jogoAux => jogoAux.Nome).ToList(),
                ClassificacaoId = jogo.ClassificacaoIndicativa.ClassificacaoIndicativaID,
                Classificacao = jogo.ClassificacaoIndicativa.Faixa,
                StatusJogo = jogo.StatusJogo,
            };
            return jogoDto;
        }

        public List<LerJogoDto> Listar()
        {
            List<Jogo> jogos = _repository.Listar();
            List<LerJogoDto> jogosDto = jogos.Select(jogosAux => LerDto(jogosAux)).ToList();

            return jogosDto;
        }

        public LerJogoDto ObterPorId(int id)
        {
            Jogo? jogoDto = _repository.ObterPorId(id);

            if(jogoDto == null)
            {
                throw new DomainException("Esse jogo não existe");
            }

            return LerDto(jogoDto);
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
            {
                throw new DomainException("Nome é obrigatório;");
            }

            if (jogoDto.Preco < 0)
            {
                throw new DomainException("Preco deve ser maior que zero;");
            }

            if (string.IsNullOrWhiteSpace(jogoDto.Descricao))
            {
                throw new DomainException("Descrição é obrigatória.");
            }

            if (jogoDto.Imagem == null || jogoDto.Imagem.Length == 0)
            {
                throw new DomainException("Imagem é obrigatória.");
            }

            if (jogoDto.GenerosId == null || jogoDto.GenerosId.Count() == 0)
            {
                throw new DomainException("Jogo deve ter ao menos um genero.");
            }
            if (jogoDto.PlataformaId == null || jogoDto.PlataformaId.Count() == 0)
            {
                throw new DomainException("Produto deve ter ao menos uma plataforma.");
            }
            if (jogoDto.ClassificacaoId == null)
            {
                throw new DomainException("Produto deve ter ao menos uma classificacao.");
            }
        }

        public void Adicionar(CriarJogoDto jogoDto, int usuarioId)
        {
            ValidarCadastro(jogoDto);

            Jogo jogo = new Jogo
            {
                Nome = jogoDto.Nome,
                Descricao = jogoDto.Descricao,
                Preco = jogoDto.Preco,
                Imagem = ImagemParaBytes.ConverterImagem(jogoDto.Imagem),
                StatusJogo = true,
                UsuarioID = usuarioId
            };

            _repository.Adicionar(jogo);
        }

        public void Remover(int id)
        {
            Jogo jogo = _repository.ObterPorId(id);

            if (jogo == null)
                throw new DomainException("Jogo não existe");

            _repository.Remover(id);
        }

        public void Atualizar(CriarJogoDto jogoDto, int id)
        {
            ValidarCadastro(jogoDto);

            Jogo jogo = _repository.ObterPorId(id);

            if(jogo == null)
               throw new DomainException("Jogo não existe");

            _repository.Atualizar(jogo);
        }
    }
}
