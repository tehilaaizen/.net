using System.Diagnostics.Metrics;
using DO;
namespace Dal
{
 static internal class DataSource
 {
        internal static List<Customer?> customers=new();
        internal static List<Product?> products=new();
        internal static List<Sale?>sales=new();
        static internal class Config
        {
            internal const int START_PRODUCT_ID= 1000;
            internal const int START_SALE_ID = 1;
            static private int run_product_id=START_PRODUCT_ID;
            static private int run_sale_id=START_SALE_ID;
            static public int Product_id => run_product_id++;
            static public int Sale_id => run_sale_id++;


        }
    }
}
