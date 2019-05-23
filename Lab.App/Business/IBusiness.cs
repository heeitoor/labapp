using Lab.App.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.App.Business
{
    interface IBusiness<T> where T : IModel
    {
        bool Salvar(T model);
    }
}
