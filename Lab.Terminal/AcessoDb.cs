using System;
using System.IO;

namespace App.Console
{
    class AcessoDb
    {
        public AcessoDb(int j)
        {
            //new AcessoDb().Ok(1, a3: 1, dateTime: DateTime.Now, nome: "lala");

            Ok(10, "", DateTime.Now, 10, a3: 10, a2: 99);

            //bool resultado = TryParse("99-", out int numeroConvertido);

            //Get();


        }

        /// <summary>
        /// Método que converte string para int.
        /// </summary>
        /// <param name="valor">Valor para ser convertido.</param>
        /// <param name="inteiroConvertido">Out param convertido!</param>
        /// <returns></returns>
        public static bool TryParse(string valor, out int inteiroConvertido)
        {
            inteiroConvertido = default(int);

            try
            {
                inteiroConvertido = Convert.ToInt32(valor);
                int d = 10, dd = 0;
                int k = (d / dd);
                return true;
            }
            catch (FormatException x)
            {
                return false;
            }
            catch (OverflowException x)
            {
                return false;
            }
            catch (DivideByZeroException x)
            {
                return false;
            }
            catch (Exception x)
            {
                return false;
            }
            finally
            {
                // vai sim :D
            }
        }

        void Ok(long l, string nome, DateTime? dateTime = null, int a1 = 0, int a2 = 0, int a3 = 0)
        {
            if (!dateTime.HasValue)
                dateTime = DateTime.Now;

            if (dateTime.Value.Second % 2 != 0)
                return;
        }

        int Get(ref int a)
        {
            a = a * 2;

            return a;
        }

        int Get(int? valor = null)
        {
            return valor.HasValue ? valor.Value : 0;
        }

        int Get2()
        {
            return 0;
        }

        public void ExceptionTest()
        {
            try
            {
                int a = 1, b = 0, c = a / b;
            }
            catch (DivideByZeroException x)
            {
                throw;
                throw x;
                //throw new Exception("Divisão por zero errada", x);
            }
        }
    }
}
