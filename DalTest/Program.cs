using DO;
using DalApi;

namespace DalTest;
internal class Program
{

    static private IDal s_dal = DalApi.Factory.Get;
    static void Main(string[] args)
    {
        try
        {
            //Initialization.Initialize(s_dal); 
            PrintMainMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
    static void PrintCustomer(Customer c)
    {
        Console.WriteLine("id " + c.id + " name " + c.name + " address " + c.address + " phone_number " + c.phone_number);
    }
    static void PrintProduct(Product p)
    {
        Console.WriteLine("id " + p.id + " name" + p.name + " amount" + p.amount + " category" + p.category + " price" + p.price);
    }
    static void PrintSale(Sale s)
    {
        Console.WriteLine("id "+s.id+" barcode "+s.barcode+" min_amount "+s.min_amount+" price "+s.price+" to_members "+s.to_members+" begin_date "+s.begin_date+" end_date "+s.end_date);
    }
    static Sale NewSale()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert barcode");
        int barcode = int.Parse(Console.ReadLine());
        Console.WriteLine("insert min amount");
        int min_amount = int.Parse(Console.ReadLine());
        Console.WriteLine("insert price");
        double price = double.Parse(Console.ReadLine());
        Console.WriteLine("insert 0 to members or eny number not to members");
        int members=int.Parse(Console.ReadLine());
        bool to_members = members==0?true:false;
        Console.WriteLine("insert length sale in days");
        int len_sale =int.Parse(Console.ReadLine());
        return new Sale(id, barcode, min_amount, price,to_members,DateTime.Now,DateTime.Now.AddDays(len_sale));
    }
    static Customer NewCustomer()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert name");
        string name = Console.ReadLine();
        Console.WriteLine("insert address");
        string address = Console.ReadLine();
        Console.WriteLine("insert phone_number");
        string phone_number = Console.ReadLine();
        return new Customer(id, name, address, phone_number);
    }
    static Product NewProduct()
    {
        Console.WriteLine("insert id");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("insert name");
        string name = Console.ReadLine();
        Console.WriteLine("insert category");
        char categ = char.Parse(Console.ReadLine());
        Console.WriteLine("insert price");
        double price = double.Parse(Console.ReadLine());
        Console.WriteLine("insert amount");
        int amount = int.Parse(Console.ReadLine());
        Category category;
        switch (categ)
        {
            case 'A': category = Category.A; break;
            case 'B': category = Category.B; break;
            case 'C': category = Category.C; break;
            case 'D': category = Category.D; break;
            case 'E': category = Category.E; break;
            default: category = Category.A; break;
        }
        return new Product(id, name, category, price, amount);
    }
    static void CreateProduct()
    {
        Product product=NewProduct();
        s_dal.product.Create(product);
    }
    static void CreateCustomer()
    {
        Customer customer=NewCustomer();
        s_dal.customer.Create(customer);
    }
    static void CreateSale()
    {
        Sale sale=NewSale();
        s_dal.sale.Create(sale);
    }
    static void Create(string item)
    {
        switch (item)
        {
            case "product":
                CreateProduct();
                break;
            case "customer":
                CreateCustomer();
                break;
            case "sale":
                CreateSale();
                break;
        }
    }
    static void ReadProduct()
    {
        Console.WriteLine("insert product id to read");
        int id=int.Parse(Console.ReadLine());
        Product p= s_dal.product.Read(id);
        PrintProduct(p);
    }
    static void ReadCustomer()
    {
        Console.WriteLine("insert customer id to read");
        int id = int.Parse(Console.ReadLine());
        Customer c = s_dal.customer.Read(id);
        PrintCustomer(c);
    }
    static void ReadSale()
    {
        Console.WriteLine("insert sale id to read");
        int id = int.Parse(Console.ReadLine());
        Sale s = s_dal.sale.Read(id);
        PrintSale(s);
    }
    static void Read(string item)
    {
        switch (item)
        {
            case "product":
                ReadProduct();
                break;
            case "customer":
                ReadCustomer();
                break;
            case "sale":
                ReadSale();
                break;
        }
    }
    static void UpdateProduct()
    {
        Product p=NewProduct();
        s_dal.product.Update(p);
    }
    static void UpdateCustomer()
    {
        Customer c=new Customer();
        s_dal.customer.Update(c);
    }
    static void UpdateSale()
    {
        Sale s=new Sale();
        s_dal.sale.Update(s);
    }
    static void Update(string item)
    {
        switch (item)
        {
            case "product":
                UpdateProduct();
                break;
            case "customer":
                UpdateCustomer();
                break;
            case "sale":
                UpdateSale();
                break;
        }
    }
    static void DeleteProduct()
    {
        Console.WriteLine("enter product id to delete");
        int id=int.Parse(Console.ReadLine());
        s_dal.product.Delete(id);
    }
    static void DeleteCustomer()
    {
        Console.WriteLine("enter customer id to delete");
        int id = int.Parse(Console.ReadLine());
        s_dal.customer.Delete(id);
    }
    static void DeleteSale()
    {
        Console.WriteLine("enter sale id to delete");
        int id = int.Parse(Console.ReadLine());
        s_dal.sale.Delete(id);
    }
    static void Delete(string item)
    {
        switch (item)
        {
            case "product":
                DeleteProduct();
                break;
            case "customer":
                DeleteCustomer();
                break;
            case "sale":
                DeleteSale();
                break;
        }
    }
    private static void PrintSubMenu(string item)
    {
        Console.WriteLine("press num to choose");
        Console.WriteLine("1. to create new " + item);
        Console.WriteLine("2. to read " + item + " by id");
        Console.WriteLine("3. to update " + item);
        Console.WriteLine("4. to delete " + item + " by id");
        int choose = int.Parse(Console.ReadLine());
        switch (choose)
        {
            case 1:
                Create(item);
                break;
            case 2:
                Read(item);
                break;
            case 3:
                Update(item);
                break;
            case 4:
                Delete(item);
                break;
            default:
                Console.WriteLine("invalid selection");
                PrintSubMenu(item);
                break;
        }
    }
    private static void PrintMainMenu()
    {
        Console.WriteLine("enter nem to choose");
        Console.WriteLine("1. to check product");
        Console.WriteLine("2. to check customer");
        Console.WriteLine("3. to check sale");
        Console.WriteLine("4. to exit");
        bool flag=true;
        int choose = int.Parse(Console.ReadLine());
        switch (choose)
        {
            case 1:
                PrintSubMenu("product");
                break;
            case 2:
                PrintSubMenu("customer");
                break;
            case 3:
                PrintSubMenu("sale");
                break;
            case 4:
                flag=false;
                break;
            default:
                Console.WriteLine("invalid selection");
                PrintMainMenu();
                break;
        }
        if (flag)
            PrintMainMenu();
    }
}
