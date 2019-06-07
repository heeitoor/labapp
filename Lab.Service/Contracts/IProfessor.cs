using System.Collections.Generic;
using System.ServiceModel;

namespace Lab.Service.Contracts
{
    [ServiceContract]
    public interface IProfessor
    {
        [OperationContract]
        //[WebInvoke(UriTemplate = "Get", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Models.Professor> Get();

        [OperationContract]
        bool Add(Models.Professor professor);

        [OperationContract]
        bool Update(Models.Professor professor);

        [OperationContract]
        bool Delete(Models.Professor professor);
    }
}
