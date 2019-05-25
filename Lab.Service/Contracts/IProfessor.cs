using Lab.Service.Models;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Lab.Service.Contracts
{
    [ServiceContract]
    public interface IProfessor
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "Get", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        ProfessorModel Get();
    }
}
