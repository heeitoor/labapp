using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Service.Contracts
{
    public interface INota
    {
        object Get();

        bool Add();

        bool Update();

        bool Delete();
    }
}
