using Royal_Games.Domains;
using Royal_Games.DTOs.CriarUsuarioDTO;
using Royal_Games.DTOs.LerUsuarioDTO;
using Royal_Games.Exceptions;
using Royal_Games.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Royal_Games.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        private static LerUsuarioDto LerDto(Usuario usuario)
        {
            return new LerUsuarioDto
            {
                Id = usuario.UsuarioID,
                Nome = usuario.Nome,
                Email = usuario.Email,
                StatusUsuario = usuario.StatusUsuario
            };
        }

        public List<LerUsuarioDto> Listar()
        {
            return _repository.Listar().Select(LerDto).ToList();
        }

        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new DomainException("Email inválido.");
        }

        public static byte[] HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new DomainException("Senha é obrigatória.");

            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        public LerUsuarioDto ObterPorId(int id)
        {
            Usuario? usuario = _repository.ObterPorId(id);
            if (usuario == null)
                throw new DomainException("Usuário não existe.");

            return LerDto(usuario);
        }

        public LerUsuarioDto ObterPorEmail(string email)
        {
            Usuario? usuario = _repository.ObterPorEmail(email);
            if (usuario == null)
                throw new DomainException("Usuário não existe.");

            return LerDto(usuario);
        }

        public LerUsuarioDto Adicionar(CriarUsuarioDto usuarioDto)
        {
            ValidarEmail(usuarioDto.Email);

            if (_repository.EmailExiste(usuarioDto.Email))
                throw new DomainException("Já existe um usuário com esse email.");

            Usuario usuario = new Usuario
            {
                Nome = usuarioDto.Nome,
                Email = usuarioDto.Email,
                Senha = HashSenha(usuarioDto.Senha),
                StatusUsuario = usuarioDto.StatusUsuario ?? true
            };

            _repository.Adicionar(usuario);
            return LerDto(usuario);
        }

        public LerUsuarioDto Atualizar(int id, CriarUsuarioDto usuarioDto)
        {
            Usuario? usuarioBanco = _repository.ObterPorId(id);
            if (usuarioBanco == null)
                throw new DomainException("Usuário inexistente.");

            ValidarEmail(usuarioDto.Email);

            usuarioBanco.Nome = usuarioDto.Nome;
            usuarioBanco.Email = usuarioDto.Email;
            usuarioBanco.Senha = HashSenha(usuarioDto.Senha);
            usuarioBanco.StatusUsuario = usuarioDto.StatusUsuario ?? true;

            _repository.Atualizar(usuarioBanco);
            return LerDto(usuarioBanco);
        }

        public void Remover(int id)
        {
            Usuario? usuario = _repository.ObterPorId(id);
            if (usuario == null)
                throw new DomainException("Usuário inexistente.");

            _repository.Remover(id);
        }
    }
}
