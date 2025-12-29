using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Customer(
        int id,
        string name,
        string address,
        string phone_number)
    {
        public Customer() : this(0, "", "", "") { }
    }
}
