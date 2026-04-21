using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {
        public IProduct product  { get; }
        public Icustomer customer { get; }
        public Isale sale { get; }
    }
}
