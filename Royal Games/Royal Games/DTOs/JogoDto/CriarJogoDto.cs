namespace Royal_Games.DTOs.JogoDto
{
    public class CriarJogoDto
    {
        public string Nome { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Preco { get; set; }
        public IFormFile Imagem { get; set; } = null!;

        public  List<int> GenerosId { get; set; } = null!;
        public List<int> PlataformaId { get; set; } = null!;
        public int? ClassificacaoId { get; set; }
    }
}
