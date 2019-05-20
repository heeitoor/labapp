using System;
using System.Text;
using System.Text.RegularExpressions;
using SYS = System;
using Business = App.Business;
using Data = App.Data;
using System.Linq;
using System.IO;

using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using App.Business;
using System.Linq.Expressions;

namespace App.Business
{
    public class Pessoa
    {
        private int idade;

        public string Nome { get; set; }

        public int Idade
        {
            get
            {
                return idade;
            }
            set
            {
                if (value > 18 && IdadeMaiorQueDezoito != null)
                {
                    IdadeMaiorQueDezoito(Nome);
                }

                idade = value;
            }
        }

        public delegate void IdadeDelegate(string name);

        public event IdadeDelegate IdadeMaiorQueDezoito;
    }
}

namespace App.Console
{
    //interface IAppException
    //{
    //    DateTime HoraQueAconteceu { get; }
    //}

    //class AppException : Exception, IAppException
    //{
    //    public DateTime HoraQueAconteceu => DateTime.Now;
    //}

    interface IAnimal
    {
        string Nome { get; set; }

        void Comer();
        void Dormir();
    }

    struct Cachorro : IAnimal
    {
        public string Nome { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Comer()
        {
            throw new NotImplementedException();
        }

        public void Dormir()
        {
            throw new NotImplementedException();
        }
    }

    class Gato : IAnimal
    {
        public string Nome { get; set; }

        public void Comer()
        {
        }

        public void Dormir()
        {
        }

        public void A()
        {

        }
    }

    interface IA
    {
        void Executar();

        //void A();
    }

    interface IB
    {
        void Executar();

        //void B();
    }

    class AB : IA, IB
    {
        public void Executar()
        {
            SYS.Console.WriteLine(this.GetType().Name);
        }

        //void IA.Executar()
        //{

        //}

        //void IB.Executar()
        //{

        //}
    }

    class CompararStrings : IComparer
    {
        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            return 0;
        }
    }

    interface IRepository<T>
    {
        void Insert(T item);
        void Delete(int id);
        IQueryable<T> Get();
    }

    class AppList<T>
        where T : IAnimal, new()
    {
        private T[] arr = new T[99];

        public int Quantidade;

        public void Teste()
        {
            Quantidade = 1;

            T t = new T();
        }

        public void Add(T item)
        {

        }
    }

    class Conversoes<Y>
        where Y : U
    {
        public static T Converter<T>(object o)
            where T : new()
        {
            return new T();
        }
    }

    class A : IQueryable<int>
    {
        public Type ElementType => throw new NotImplementedException();

        public Expression Expression => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AppList<Gato> lista = new AppList<Gato>();

            var k = (IAnimal)new Gato();


            AB obj = new AB();
            obj.Executar();

            IA ia = obj;
            ia.Executar();

            IB ib = obj;
            ib.Executar();



            //Gato gato = new Gato();
            //IAnimal animal = gato;


            //Pessoa p1 = new Pessoa
            //{
            //    Nome = "Zelda"
            //};

            ////p1.IdadeMaiorQueDezoito += ExecutaQuandoForMaior;

            //Func<int, bool> seEhPar = (numero) =>
            //{
            //    return numero % 2 == 0;
            //};

            //A(seEhPar, 9);

            //bool par = seEhPar(9);

            ////p1.IdadeMaiorQueDezoito += (name) =>
            ////{
            ////    SYS.Console.WriteLine($"O {name} é maior de dezoito anos.");
            ////};

            //p1.IdadeMaiorQueDezoito += ExecutaQuandoForMaior;

            //p1.Idade = 19;

            ////aqui eu nao quero mais oe vento

            //p1.IdadeMaiorQueDezoito -= ExecutaQuandoForMaior;

            //return;

            //var arr = new[] { 1, 2 };
            //var arr2 = new object[10];

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add("1");


            //var names = new List<string>();
            //names.Add("heitor");
            //names.Add("arthur");
            //names.Add("zelda");

            //// foreach (string nome in nomes) { }


            //var consultaLambda = names
            //    .Select(x =>
            //    {
            //        return x;
            //    }).ToList();
            ////.Where(x => true)
            ////.OrderBy(x => x);

            //var consulta = from name
            //               in names
            //               select name;



            //var resultado = consulta.ToList();

            ////var consulta2 = from name
            ////                in consulta
            ////                select new
            ////                {
            ////                    inicial = name.name
            ////                };


            ////IEnumerable
            ////IQueryable

            //Queue queue = new Queue();
            //Queue<int> qQueue = new Queue<int>();

            //qQueue.Enqueue(5);
            //qQueue.Enqueue(6);
            //qQueue.Enqueue(10);

            //qQueue.Dequeue();

            //Stack<int> stack = new Stack<int>();

            //stack.TryPop(out int rt);

            //stack.Push(1);
            //stack.Push(10);
            //stack.Push(100);

            //stack.Pop();

            //Hashtable hashtable = new Hashtable();

            //hashtable.Add(hashtable.Count, "indice 1");

            ////hashtable[0];

            //if (!hashtable.ContainsKey(1))
            //    hashtable.Add(hashtable.Count, "indice 1");

            //SortedList<int, string> alunos = new SortedList<int, string>();

            //alunos.Add(99, "heitor");
            //alunos.Add(9, "caju");
            //alunos.Add(50, "amora");
            //alunos.TryAdd(99, "lala");

            //Dictionary<string, string> dicionario = new Dictionary<string, string>();
            //KeyValuePair<string, string> keyValuePair;


            //dicionario.Add("00002", "heitor");
            //dicionario.Add("00001", "heitor");

            //string a = dicionario["00002"];

            //StringDictionary s = new StringDictionary();

            //NameValueCollection ab = new NameValueCollection();


            //return;

            //Dictionary<string, int> dic = new Dictionary<string, int>();

            //new VendaClasse();
            //int w = (int)DatabaseOperation.Insert;
            //DatabaseOperation r = (DatabaseOperation)9;

            //// insert update delete select
            //// POST - 1 DELETE - 2 PUT - 3 PATCH - 4

            //OperacaoDb(1);




            ////Stopwatch s = new Stopwatch();
            ////s.Start();

            ////AcessoDb acessoDb = new AcessoDb();

            ////s.Stop();




            ////int valor = 10;

            ////acessoDb.Get(ref valor);





            ////MetodoSimples();


            //int.Parse("olá");


            //int[] idades = new int[99];
            //string[] nomes = new string[99];
            //foreach (var item in idades)
            //{

            //}
            //for (int j = 0; j < idades.Length; j++)
            //{
            //    string nome = nomes[j];
            //}

            //int i = 0;
            //// arrays!

            //long[] longArray = new long[10];

            //for (i = 0; i < longArray.Length; i++)
            //{
            //    //
            //}

            //var h = args[10];


            //// laços de repetição

            //// enquanto uma condição for satisfeita!
            //while (i < 10)
            //{
            //    // executa isso aqui!
            //    i++;
            //}
            //for (i = 0; i < 10; i++) { }
            //do
            //{
            //    string arg = args[i];
            //} while (i < 10);
            //foreach (int item in Enumerable.Range(0, 10))
            //{

            //}


            //int idade = 18;

            //switch (idade)
            //{
            //    case 18:
            //        // faz alguma coisa
            //        return;
            //        break;
            //    default:
            //        // caso padrão, caso nenhum condição tenha sido satisfeita!
            //        break;
            //}

            //// se uma condição for satisfeita
            //if (true)
            //{
            //    // faz alguma coisa
            //}
            //// senão se
            //else if (true)
            //{
            //    // faz alguma coisa
            //}
            //// senão
            //else
            //{
            //    // faz alguma coisa
            //}


            ////string numero = "26a";

            ////var c = Regex.Matches("test1e", "\\d");

            ////foreach (Match item in c)
            ////{

            ////}

            ////// int numeroConvertido;

            ////string teste = "  \"heitor\"   ";

            ////bool funcionou = int.TryParse(numero, out int numeroConvertido);

            ////// se funcionout == true { } se não { }

            //////int numeroConvertido = Convert.ToInt32(numero);

            ////StringBuilder stringBuilder;

            ////stringBuilder = new StringBuilder();

            ////stringBuilder.Append("Nome da pessoa");

            ////stringBuilder.Append("Heitor");
            ////stringBuilder.Append(true.ToString());
            ////stringBuilder.Append("Sousa");

            ////string j = "heitor";

            ////j += "sousa";

            ////string.Format("{0:d}", DateTime.Now);

            ////string s = $"{DateTime.Now.ToShortDateString()}";

            ////stringBuilder.ToString();

            ////int numero = 10, k = 9;
            ////long q;

            ////q = 99;

            ////var g = "56";

            ////dynamic a = 10;

            ////a = "teste";
        }

        string A(string p, TipoPessoa tipoPessoa = TipoPessoa.Marciano)
        {
            string retorno;

            switch (tipoPessoa)
            {
                case TipoPessoa.Fisica:
                case TipoPessoa.Juridica:

                    if (tipoPessoa == TipoPessoa.Fisica)
                    {

                    }

                    break;
                case TipoPessoa.Alienigena:
                    break;
                case TipoPessoa.Marciano:
                    break;
                default:
                    break;
            }

            if (tipoPessoa == TipoPessoa.Fisica)
            {

            }
            else if (tipoPessoa == TipoPessoa.Juridica)
            {

            }
            else if (tipoPessoa == TipoPessoa.Alienigena)
            {

            }
            else if (tipoPessoa == TipoPessoa.Marciano)
            {

            }
            else
            {

            }

            switch (p)
            {
                case "teste":
                    retorno = "teste";
                    break;
                default:
                    retorno = "default";
                    break;
            }

            return retorno;
        }

        static string MetodoSimples(string name)
        {
            return name.ToUpper();
        }

        static void OperacaoDb(int operacao)
        {
            switch (operacao)
            {
                case 1:
                    SYS.Console.WriteLine("insert");
                    break;
                case 2:
                    SYS.Console.WriteLine("update");
                    break;
                case 3:
                    SYS.Console.WriteLine("delete");
                    break;
                case 4:
                    SYS.Console.WriteLine("select");
                    break;
            }
        }

        static void OperacaoDbEnum(DatabaseOperation databaseOperation)
        {
            switch (databaseOperation)
            {
                case DatabaseOperation.Insert:
                    break;
                case DatabaseOperation.Update:
                    break;
                case DatabaseOperation.Delete:
                    break;
                case DatabaseOperation.Select:
                    break;
            }
        }
        static void ExecutaQuandoForMaior(string name)
        {
            SYS.Console.WriteLine($"O {name} é maior de dezoito anos.");
        }

        static void A(Func<int, bool> funcao, int numero)
        {
            funcao(numero);
        }
    }

    enum TipoPessoa
    {
        Fisica,
        Juridica,
        Alienigena,
        Marciano
    }

    enum DatabaseOperation
    {
        Insert = 1,
        Update,
        Delete = 7,
        Select
    }
}

namespace App.Data
{
    class Pessoa { }
}