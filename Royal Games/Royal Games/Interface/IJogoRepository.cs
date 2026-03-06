using Royal_Games.Domains;
using System.Collections.Generic;

namespace Royal_Games.Interface
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo? ObterPorId(int id);

        byte[] ObterImagem(int id);

        List<Jogo> ObterPorPlataforma(string plataforma);
        List<Jogo> ObterPorGenero(string genero);

        void Adicionar(Jogo jogo, List<int> generosId, List<int> plataformaId, int classificacaoId);

        void Atualizar(Jogo jogo, List<int> generosId, List<int> plataformaId, int classificacaoId);

        void Remover(int id);

        bool NomeExiste(string nome, int? id = null);
    }
}