using System;
using System.Collections.Generic;
using System.Linq;
using Lab.Data;
using Lab.Data.Entity;
using Lab.Models;

namespace Lab.Business
{
    public class IdentificacaoBusiness
    {
        public Identificacao Login(ProfessorCredencial credencial)
        {
            using (LabContextCodeFirst context = new LabContextCodeFirst())
            {
                Action a = () =>
                {
                    Console.WriteLine("qualquer");
                };

                Func<string, string> z = (s) =>
                {
                    return s + "z";
                };

                List<Data.Entity.Professor> p = Enumerable.Range(0, 10).Select(x =>
                {
                    a();

                    return new Data.Entity.Professor
                    {
                        Id = x,
                        Nome = $"Professor {x}"
                    };
                }).ToList();

                var q2 = context.Professor.ToList().Select(x => new
                {
                    Nome = z(x.Nome)
                });

                var q3 = q2.ToList();

                //var q = context.Professor.SelectMany(x => x.Nota.Select(y => new
                //{
                //    Nome = x.Nome,
                //    Nota = y.Valor
                //}))
                //.GroupBy(x => x.Nome)
                //.Select(x => new
                //{
                //    Nome = x.Key,
                //    Sum = x.Sum(y => y.Nota)
                //})
                //.ToList();


                bool success = context.Professor.Any(x => x.Login == credencial.Login && x.Senha == credencial.Senha);

                if (success)
                {
                    return new Identificacao
                    {
                        Token = Guid.NewGuid().ToString()
                    };
                }
                else
                {
                    return new Identificacao { };
                }
            }
        }
    }
}
