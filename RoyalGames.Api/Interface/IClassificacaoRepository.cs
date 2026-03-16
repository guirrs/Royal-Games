using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IClassificacaoRepository
    {
        public List<ClassificacaoIndicativa> Listar();
        public ClassificacaoIndicativa ObterPorId(int id);

        public void Adicionar(ClassificacaoIndicativa classificacao);
        public void Atualizar(ClassificacaoIndicativa classificacao);
        public void Remover(ClassificacaoIndicativa classificacao);
    }
}
