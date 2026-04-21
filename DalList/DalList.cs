using DalApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        private DalList() { }
        private readonly DalList instance;
        public DalList Instance
        {
            get { return instance; }
        }

        public Iproduct product => new ProductImplementation();
        public Icustomer customer => new CustomerImplementation();
        public Isale sale=>new SaleImplementation();
    }
}
