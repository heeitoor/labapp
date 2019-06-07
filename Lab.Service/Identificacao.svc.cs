using Lab.Models;
using Lab.Service.Contracts;

namespace Lab.Service
{
    public class Identificacao : IIdentificacao
    {
        public Models.Identificacao Login(ProfessorCredencial professorCredencial)
        {
            return new Models.Identificacao { };
        }

        public bool Logout(Models.Identificacao identificacao)
        {
            return true;
        }
    }
}
