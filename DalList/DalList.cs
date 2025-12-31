using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DalList : IDal
    {
        public Iproduct product => new ProductImplementation();
        public Icustomer customer => new CustomerImplementation();
        public Isale sale=>new SaleImplementation();
    }
}
