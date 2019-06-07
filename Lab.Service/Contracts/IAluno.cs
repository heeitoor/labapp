using System.Collections.Generic;
using System.ServiceModel;

namespace Lab.Service.Contracts
{
    [ServiceContract]
    public interface IAluno
    {
        [OperationContract]
        IEnumerable<Models.Aluno> Get();

        [OperationContract]
        bool Add(Models.Aluno aluno);

        [OperationContract]
        bool Update(Models.Aluno aluno);

        [OperationContract]
        bool Delete(int id);
    }
}
