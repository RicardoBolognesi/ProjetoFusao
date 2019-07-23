using ProjetoTeste2.Domains.Interfaces;
using ProjetoTeste2.Domains.Interfaces.Repository;

namespace ProjetoTeste2.Domains.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
