using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public record Sale(
        int id,
        int barcode,
        int min_amount,
        double price,
        bool to_members,
        DateTime begin_date,
        DateTime end_date)
    {
        private static int count=1;
        public Sale() : this(count++, 0, 0, 0, true, DateTime.Now,DateTime.Now) { }
    }
}
