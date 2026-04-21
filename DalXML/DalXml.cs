using DalApi;

namespace Dal;

public  sealed class DalXml : IDal
{
    public IProduct product =>  new ProductImplementation();

    public Icustomer customer =>  new CustomerImplementation();

    public Isale sale =>  new SaleImplementation();
    private static readonly DalXml instance =new DalXml();
    public static DalXml Instance
    {
        get { return instance; }
    }
    private DalXml() { }
    
    
}
