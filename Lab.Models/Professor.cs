using System;
using System.Runtime.Serialization;

namespace Lab.Models
{
    [Serializable]
    [DataContract]
    public class ProfessorCredencial
    {
        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Senha { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Professor : ProfessorCredencial
    {
        [DataMember]
        public int Id { get; set; }
    }
}
