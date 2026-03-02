using Royal_Games.Domains;

namespace Royal_Games.Interface
{
    public interface IClassificacaoRepository
    {
        List<ClassificacaoIndicativa> Listar();
        ClassificacaoIndicativa ObterPorId(int id);

        public void Adicionar(ClassificacaoIndicativa classificacao);
        public void Atualizar(ClassificacaoIndicativa classificacao);
        public void Remover(ClassificacaoIndicativa remover);
    }
}
