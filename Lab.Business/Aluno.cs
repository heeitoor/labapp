using Lab.Models;
using System.Collections.Generic;

namespace Lab.Business
{
    public class AlunoBusiness
    {
        public List<Aluno> Get(AlunoFiltro filtro)
        {
            List<Aluno> result = null;

            //using (DataAccess dataAccess = new DataAccess())
            //{
            //    StringBuilder stringBuilder = new StringBuilder();

            //    stringBuilder.AppendLine("SELECT * FROM Aluno a");

            //    if (!string.IsNullOrEmpty(filtro.Nome))
            //    {
            //        stringBuilder.AppendLine($"WHERE a.Nome LIKE '%{filtro.Nome}%'");
            //    }

            //    result = dataAccess.Query(stringBuilder.ToString(), x => new Aluno
            //    {
            //        Id = (x["Id"] as int?).Value,
            //        Nome = x["Nome"].ToString(),
            //        DataNascimento = (x["Nascimento"] as DateTime?).Value
            //    });
            //}

            return result;
        }

        public bool Save(Aluno aluno)
        {
            bool result = false;

            //using (DataAccess dataAccess = new DataAccess())
            //{
            //    string query = string.Empty;

            //    if (aluno.Id > 0)
            //    {
            //        query = $"UPDATE Aluno SET Nome = '${aluno.Nome}', Nascimento = '${aluno.DataNascimento.ToString("dd-MM-YYYY")}' WHERE Id = ${aluno.Id}";
            //        result = dataAccess.Execute(query) > 0;
            //    }
            //    else
            //    {
            //        query = $"INSERT INTO Aluno (Nome, Nascimento) VALUES ('${aluno.Nome}', '${aluno.DataNascimento.ToString("dd-MM-YYYY")}')";
            //        result = dataAccess.Execute(query) > 0;
            //    }
            //}

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            //using (DataAccess dataAccess = new DataAccess())
            //{
            //    result = dataAccess.Execute($"DELETE Aluno WHERE Id = ${id}") > 0;
            //}

            return result;
        }
    }
}