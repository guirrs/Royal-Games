using Royal_Games.Interface;

namespace Royal_Games.Application.Services
{
    public class PlataformaService
    {
        private readonly IPlataformaRepository _repository;

        public PlataformaService(IPlataformaRepository repository)
        {
            _repository = repository;
        }





    }
}
