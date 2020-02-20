using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinealStructures.Interfaces
{
    interface ILinearDataStructure<T>
    {
        void Insert(T value);
        bool Find(T value);

    }
}
