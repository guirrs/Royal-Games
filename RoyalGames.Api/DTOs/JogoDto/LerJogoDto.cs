namespace Royal_Games.DTOs.JogoDto
{
    public class LerJogoDto
    {
        public int JogoId {  get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco {  get; set; }
        public bool? StatusJogo { get; set; }
        public DateTime DataLancamento { get; set; }

        // Genero
        public List<int>? GenerosId { get; set; }
        public List<string>? Generos {  get; set; }

        // Plataforma
        public List<int>? PlataformaId {  get; set; }
        public List<string>? Plataforma { get; set; }

        // Usuario
        public int? UsuarioID { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioEmail { get; set; }

        // Classificacao
        public int ClassificacaoId { get; set; }
        public string? Classificacao {  get; set; }
    }
}
