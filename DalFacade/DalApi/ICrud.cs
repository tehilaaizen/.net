using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public
        interface ICrud<T>
    {
        int Create(T t);
        T? Read(int id);
        List<T> ReadAll();
        void Update(T t);
        void Delete(int id);
    }
}
