using System.ServiceModel;

namespace Lab.Service.Contracts
{
    [ServiceContract]
    public interface IIdentificacao
    {
        [OperationContract]
        Models.Identificacao Login(Models.ProfessorCredencial professorCredencial);

        [OperationContract]
        bool Logout(Models.Identificacao identificacao);
    }
}
