using System.Runtime.Serialization;

namespace Lab.Service.Models
{
    [DataContract]
    public class ProfessorModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nome { get; set; }
    }
}