namespace Royal_Games.DTOs.CriarUsuarioDTO
{
    public class CriarUsuarioDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; } 
        public bool? StatusUsuario { get; set; } = true;
    }
}
