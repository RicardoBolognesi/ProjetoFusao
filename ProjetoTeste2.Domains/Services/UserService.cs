using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Domains.Interfaces.Service;
using ProjetoTeste2.Domains.Utils;

namespace ProjetoTeste2.Domains.Services
{
    public class UserService: IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool EnviarEmail(string destinatario, string assunto, string msg)
        {
           return Utilities.EnviaEmail(destinatario, assunto, msg);
        }
    }
}
