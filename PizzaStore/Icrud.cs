using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    interface Icrud<GenKey, GenObject>
    {

        void Create(GenObject Obj);
        void Read(IdKey value);
        void Update(StoringObject Obj);
        void Delete(IdKey value);

    }
}
