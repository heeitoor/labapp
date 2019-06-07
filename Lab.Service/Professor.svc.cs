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
            return Enumerable.Empty<Models.Professor>();
        }

        public bool Update(Models.Professor professor)
        {
            throw new System.NotImplementedException();
        }
    }
}
