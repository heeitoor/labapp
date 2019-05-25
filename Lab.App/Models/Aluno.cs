using System;
using System.Xml.Serialization;

namespace Lab.App.Models
{
    [Serializable]
    public class AlunoFiltro
    {
        public string Nome { get; set; }
    }

    [Serializable]
    public class Aluno : AlunoFiltro
    {
        [XmlElement("Cod")]
        public int Id { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
