using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IJogoRepository
    {
        public List<Jogo> Listar();
        public Jogo ObterPorId(int id);

        public byte[] ObterImagem(int id);
        public void Adicionar(Jogo jogoDto);
        public void Remover (int  id);
        public void Atualizar(Jogo jogoDto);
    }
}
