using Royal_Games.Domains;
using Royal_Games.DTOs.LogJogoDto;
using Royal_Games.Exceptions;
using Royal_Games.Interface;


namespace Royal_Games.Application.Services
{
    public class LogJogoService
    {
        private readonly ILogJogoRepository _logRepository;

        public LogJogoService(ILogJogoRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public List<LerLogJogoDto> Listar()
        {
            List<Log_AlteracaoJogo> log = _logRepository.Listar();

            List<LerLogJogoDto> listaLogJogo = log.Select(log => new LerLogJogoDto
            {
                LogId = log.AlteracaoID,
                JogoId = log.JogoID,
                NomeAnterior = log.NomeAnterior,
                PrecoAnterior = log.PrecoAnterior,
                DataAlteracao = log.DataAlteracao,
            }).ToList();
            return listaLogJogo;
        }

        public List<LerLogJogoDto> ListarPorJogo(int jogoId)
        {

            if (!_logRepository.VerificarJogo(jogoId))
            {
                throw new DomainException("Jogo não encontrado ou não existente");
            }

            List<Log_AlteracaoJogo> logs = _logRepository.ListarPorJogo(jogoId);

            List<LerLogJogoDto> listaLogProduto = logs.Select(log => new LerLogJogoDto
            {
                LogId = log.AlteracaoID,
                JogoId = log.JogoID,
                NomeAnterior = log.NomeAnterior,
                PrecoAnterior = log.PrecoAnterior,
                DataAlteracao = log.DataAlteracao,
            }).ToList();

            if(listaLogProduto.Count == 0)
            {
                throw new DomainException("O jogo atual não possui alterações");
            }

            return listaLogProduto;
        }
    }
}