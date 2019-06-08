using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Service.Contracts;

namespace Lab.Service
{
    public class Professor : IProfessor
    {
        public bool Add(Models.Professor professor)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Models.Professor professor)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Models.Professor> Get()
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.Professor professor)
        {
            throw new NotImplementedException();
        }

        public Models.Professor GetById(int professorId)
        {
            throw new NotImplementedException();
        }
    }
}
