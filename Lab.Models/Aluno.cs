using System;
using System.Runtime.Serialization;

namespace Lab.Models
{
    [Serializable]
    [DataContract]
    public class AlunoFiltro
    {
        public string Nome { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Aluno : AlunoFiltro
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime DataNascimento { get; set; }
    }
}
