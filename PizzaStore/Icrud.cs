using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    interface Icrud<Tkey, Tobject>
    {

        void Create(Tobject Obj);
        void Read(Tkey value);
        void Update(Tobject Obj);
        void Delete(Tkey value);

    }
}
