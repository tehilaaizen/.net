using DO;
using DalApi;
namespace DalTest
{
    public static class Initialization
    {
        private static Iproduct? p_dalProduct=new ProductImplementation();
        private static Icustomer? c_dalCustomer=new CustomerImplementation();
        private static Isale? s_dalSale=new SaleImplementation();
        private static void CreateProducts()
        {
            if (p_dalProduct != null)
            {
                p_dalProduct.Create(new Product(1, "A", Category.A, 100, 40));
                p_dalProduct.Create(new Product(2, "B", Category.B, 200, 10));
                p_dalProduct.Create(new Product(3, "C", Category.C, 300, 10));
                p_dalProduct.Create(new Product(4, "D", Category.D, 400, 50));
                p_dalProduct.Create(new Product(5, "E", Category.E, 500, 20));
            }
        }
        private static void CreateCustomer() 
        {
            if (c_dalCustomer != null)
            {
                c_dalCustomer.Create(new Customer(1, "Shira", "Htamar", "089297340"));
                c_dalCustomer.Create(new Customer(2, "Chavi", "Rashbi", "0527635012"));
                c_dalCustomer.Create(new Customer(3, "Sara", "Rambam", "089760169"));
                c_dalCustomer.Create(new Customer(4, "Tamar", "Hzait", "0534104310"));
                c_dalCustomer.Create(new Customer(5, "Lea", "Hazon Eish", "0527646008"));
            }
        }
        private static void CreateSales()
        {
            if (s_dalSale != null)
            {
                s_dalSale.Create(new Sale(1, 1000, 0, 300, true, DateTime.Now, new DateTime(2026, 6, 07)));
                s_dalSale.Create(new Sale(2, 1001, 1, 470, false, DateTime.Now, new DateTime(2026, 2, 12)));
                s_dalSale.Create(new Sale(3, 1002, 0, 560, true, DateTime.Now, new DateTime(2026, 7, 12)));
                s_dalSale.Create(new Sale(4, 1003, 2, 790, false, DateTime.Now, new DateTime(2026, 1, 15)));
                s_dalSale.Create(new Sale(5, 1004, 1, 860, true, DateTime.Now, new DateTime(2026, 6, 02)));
            }
        }

        public static void Initialize(Iproduct?p,Icustomer?c,Isale?s) 
        { 
            p_dalProduct = p;
            c_dalCustomer = c;
            s_dalSale = s;
            CreateCustomer();
            CreateProducts();
            CreateSales();
        }
    }
}
