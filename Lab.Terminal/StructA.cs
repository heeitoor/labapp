using System;

namespace App.Console
{
    struct VendaStruct
    {
        public VendaStruct(string vendedorNome, string vendedorSobrenome, int idade)
        {
            this.vendedorNome = vendedorNome;
            this.vendedorSobrenome = vendedorSobrenome;
            this.idade = idade;
            this.tags = new int[]
            {
                1,
                2
            };

            Idade = idade;
        }

        private string vendedorNome;
        private string vendedorSobrenome;
        private int idade;
        private int[] tags;

        public int this[int index]
        {
            get
            {
                return tags[index];
            }
            set
            {
                tags[index] = value;
            }
        }

        public string VendedorNome
        {
            get
            {
                return vendedorNome;
            }
            set
            {
                vendedorNome = value;
            }
        }

        public string VendedorSobrenome
        {
            get
            {
                return vendedorSobrenome;
            }
            set
            {
                vendedorSobrenome = value;
            }
        }

        public string VendedorNomeCompleto
        {
            get
            {
                return $"{vendedorNome} {vendedorSobrenome}";
            }
        }

        public int Idade
        {
            get
            {
                return idade;
            }
            private set
            {
                idade = value;
            }
        }
    }

    class VendaClasse
    {
        public VendaClasse()
        {
            var s = new VendaStruct("Heitor", "Sousa", 22);

            string m = s.VendedorNomeCompleto.ToUpper();

            //s.tags[1]
            s[1] = 9;

            int valorDoVetor = s[1];
        }

    }
}
