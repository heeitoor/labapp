using Lab.Business;
using Lab.Models;
using Lab.Service.Contracts;
using System;

namespace Lab.Service
{
    public class Identificacao : IIdentificacao
    {
        public Lazy<IdentificacaoBusiness> Business = new Lazy<IdentificacaoBusiness>(() =>
        {
            return new IdentificacaoBusiness();
        });

        public Models.Identificacao Login(ProfessorCredencial professorCredencial)
        {
            return Business.Value.Login(professorCredencial);
        }

        public bool Logout(Models.Identificacao identificacao)
        {
            return true;
        }
    }
}
