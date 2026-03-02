namespace Royal_Games.DTOs.UsuarioDTO
{
    public class CriarUsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] Senha { get; set; }
        public bool? StatusUsuario { get; set; } = true;
    }
}
