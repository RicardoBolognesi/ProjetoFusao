using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTeste2.Domains.Interfaces.Service
{
    public interface IUserService
    {
        bool EnviarEmail(string destinatario, string assunto, string msg);
    }
}
