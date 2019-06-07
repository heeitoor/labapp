//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Lab.Extensions.Object;
//using Lab.Terminal;

//namespace Lab.Extensions.Object
//{
//    public class A
//    {

//    }

//    public static class Extensions
//    {
//        public static int ToInteiro(this object obj)
//        {
//            return (int)obj;
//        }

//        public static string ToJson(this object obj)
//        {
//            return string.Empty;
//        }

//        public static string ToCPF(this object obj)
//        {
//            return string.Empty;
//        }
//    }
//}

//namespace Lab.Terminal
//{
//    interface IDataCadastro
//    {
//        DateTime DataCadastro { get; set; }
//    }

//    interface IPessoa : IDataCadastro
//    {
//        IIR Declarador { get; set; }

//        void DeclaradorDeIR(IDadosIR dados);
//    }

//    interface IIR { void Declarar(IDadosIR dados); }

//    class DeclaradorPF : IIR
//    {
//        public void Declarar(IDadosIR dados)
//        {
//            Console.WriteLine("Declara o IR do PF.");
//        }
//    }

//    interface IDadosIR { }

//    abstract class Pessoa : IPessoa
//    {
//        public DateTime DataCadastro { get; set; }
//        public IIR Declarador { get; set; }
//        public string Nome { get; set; }

//        public Pessoa() { }

//        public Pessoa(IIR declarador)
//        {
//            Declarador = declarador;
//        }

//        public void DeclaradorDeIR(IDadosIR dados)
//        {
//            if (Declarador != null)
//                throw new Exception("Declarador não instanciado...");

//            MetodoAbstrato();

//            Declarador.Declarar(dados);
//        }

//        public abstract void MetodoAbstrato();

//        public virtual void P(string nome)
//        {
//            Nome = nome;
//        }

//        protected void TesteProtected()
//        {
//            TestePrivate();
//        }

//        private void TestePrivate() { }
//    }

//    class AppException : Exception
//    {
//        public DateTime HoraQueAconteceu => DateTime.Now;
//    }

//    class PessoaFisica : Pessoa
//    {
//        public PessoaFisica(DeclaradorPF declaradorPF) : base(declaradorPF)
//        {

//        }

//        public override void MetodoAbstrato()
//        {
//        }

//        public new void DeclaradorDeIR(IDadosIR dados)
//        {
//            base.DeclaradorDeIR(dados);
//        }

//        public sealed override void P(string nome)
//        {
//            base.P(nome);

//            Nome += DateTime.Now.ToShortTimeString();
//        }
//    }

//    sealed class PessoaJuridica : Pessoa
//    {
//        public override void MetodoAbstrato()
//        {
//            throw new NotImplementedException();
//        }

//        void K(PessoaJuridica pj)
//        {
//        }
//    }

//    class Program
//    {
//        // async static Task Main
//        public static void Main(string[] args)
//        {
//            //PessoaJuridica pj = new PessoaJuridica();
//            PessoaFisica pf = new PessoaFisica(new DeclaradorPF());
            
//            object obj = 10;

//            int k = (int)obj;

//            obj.ToInteiro();

//            //new Pessoa();
//            //new PessoaFisica();

//            //IIR declaradorInstancia;

//            pf.DeclaradorDeIR(null);
//        }
//    }

//    class Beverage
//    {
//        public Beverage()
//        {
//            B = "Passou por Beverage.";
//        }

//        public string B { get; set; }
//    }

//    class Coffee : Beverage
//    {
//        public Coffee() : base()
//        {
//            C = "Passou por Coffee.";
//        }

//        public string C { get; set; }
//    }

//    class Expresso : Coffee
//    {
//        public Expresso() : base()
//        {
//            E = "Passou por Expresso";
//        }

//        public string E { get; set; }
//    }
//}
