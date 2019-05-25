using Lab.App.Data;
using Lab.App.Models;
using Lab.App.Extensions;

namespace Lab.App.Business
{
    public class ProfessorBusiness
    {
        public bool Login(Professor professor)
        {
            bool success = false;

            using (DataAccess dataAccess = new DataAccess())
            {
                var dados = dataAccess.Query($"SELECT * " +
                    $"FROM Professor p " +
                    $"WHERE p.Login = '{professor.Login}' AND p.Senha = '{professor.Senha}'");

                success = dados.HasRows();
            }

            return success;
        }
    }
}
