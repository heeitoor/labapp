using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.RFLCTN
{
    [Context(Name = "Classes de Pessoas")]
    public class Pessoa
    {
        public Pessoa()
        {
            Nome = "Nome Padrão";
        }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Nome}";
        }

        public void Yo()
        {

        }
    }
}
