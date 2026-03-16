namespace Royal_Games.DTOs.JogoDto
{
    public class AtualizarJogoDto
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public IFormFile Imagem { get; set; } = null!;

        public List<int> GeneroId { get; set; } = null!;
        public List<int> PlataformaId { get; set; } = null!;
        public int ClassificacaoId { get; set; }
        public bool? StatusJogo { get; set; }
    }
}