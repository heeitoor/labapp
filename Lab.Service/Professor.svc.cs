using Lab.Service.Contracts;
using Lab.Service.Models;

namespace Lab.Service
{
    public class Professor : IProfessor
    {
        public ProfessorModel Get()
        {
            return new ProfessorModel
            {
                Id = 1,
                Nome = "Heitor"
            };
        }
    }
}
