using Royal_Games.Exceptions;

namespace Royal_Games.Application.Regras
{
    public class ValidarAlteracaoHorario
    {
        public static void ValidarHorario()
        {
            var agora = DateTime.Now.TimeOfDay;
            var abertura = new TimeSpan(10); //16
            var fechamento = new TimeSpan(23);

            var estaAberto = agora >= abertura && agora <= fechamento;
            if (estaAberto)
            {
                throw new DomainException("Jogo so pode ser alterado no horario de funcionamento");
            }
        }

    }
}


