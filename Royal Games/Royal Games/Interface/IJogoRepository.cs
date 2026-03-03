using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IJogoRepository
    {
        public List<Jogo> Listar();
        public Jogo ObterPorId(int id);

        public IFormFile ObterImagem(Jogo jogoDto);
        public void Adcionar(Jogo jogoDto);
        public void Remover (int  id);
        public void Atualizar(Jogo jogoDto);
    }
}
