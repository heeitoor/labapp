using System;
using System.Runtime.Serialization;

namespace Lab.Models
{
    [Serializable]
    [DataContract]
    public class Identificacao
    {
        [DataMember]
        public string Token { get; set; }
    }
}
