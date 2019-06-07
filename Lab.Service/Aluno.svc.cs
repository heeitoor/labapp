using Lab.Models;
using Lab.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab.Service
{
    public class Aluno : IAluno
    {
        public bool Add(Models.Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Aluno> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.Aluno aluno)
        {
            throw new NotImplementedException();
        }
    }
}
