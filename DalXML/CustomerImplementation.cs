using DalApi;
using DO;
using System.Xml.Linq;

namespace Dal;
internal class CustomerImplementation : Icustomer
{
    private const string FILE_PATH = @"customers.xml";
    private const string ID = "Id";
    private const string NAME = "Name";
    private const string ADDRESS = "Address";
    private const string PHONE_NUMBER = "PhoneNumber";
    private const string CUSTOMER = "Customer";
    public int Create(Customer customer)
    {
        XElement customersXml = XElement.Load(FILE_PATH);
        if (customersXml.Descendants(CUSTOMER).Any())
        {
            foreach (XElement c in customersXml.Descendants(ID))
            {
                if (int.Parse(c.Value) == customer.id)
                    throw new DalIdAlreadyExistsException("customer id already exists");
            }
        }
        XElement customerXml = new XElement(CUSTOMER);
        customerXml.Add(new XElement(ID, customer.id));
        customerXml.Add(new XElement(NAME, customer.name));
        customerXml.Add(new XElement(ADDRESS, customer.address));
        customerXml.Add(new XElement(PHONE_NUMBER, customer.phone_number));
        customersXml.Add(customerXml);
        customersXml.Save(FILE_PATH);
        return customer.id;
    }

    public void Delete(int id)
    {
        XElement customersXml = XElement.Load(FILE_PATH);
        XElement idToDelete = customersXml.Descendants(ID).FirstOrDefault(n => int.Parse(n.Value) == id);
        if (idToDelete == null)
            throw new DalIdNotFoundException("customer id not found");
        idToDelete.Parent.Remove();
        customersXml.Save(FILE_PATH);
    }

    public Customer? Read(int id)
    {
        XElement customersXml = XElement.Load(FILE_PATH);
        Customer customer;
        XElement idToRead = customersXml.Descendants(ID).FirstOrDefault(n => int.Parse(n.Value) == id);
        if (idToRead == null)
            throw new DalIdNotFoundException("customer id not found");
        XElement customerToRead = idToRead.Parent;
        customer = new Customer(
            int.Parse(customerToRead.Attribute(ID)?.Value),
            customerToRead.Attribute(NAME)?.Value,
            customerToRead.Attribute(ADDRESS)?.Value,
            customerToRead.Attribute(PHONE_NUMBER)?.Value
            );
        return customer;
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        XElement customersXml = XElement.Load(FILE_PATH);
        List<Customer> customers = new List<Customer>();
        foreach (XElement idXml in customersXml.Descendants(ID))
            customers.Add(Read(int.Parse(idXml.Value)));
        return customers.FirstOrDefault(filter);
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter)
    {
        XElement customersXml = XElement.Load(FILE_PATH);
        List<Customer> customers = new List<Customer>();
        foreach (XElement idXml in customersXml.Descendants(ID))
            customers.Add(Read(int.Parse(idXml.Value)));
        if (filter != null)
            customers = customers.Where(filter).ToList();
        return customers;
    }

    public void Update(Customer customer)
    {
        XElement customersXml = XElement.Load(FILE_PATH);
        XElement idToUpdate = customersXml.Descendants(ID).FirstOrDefault(n => int.Parse(n.Value) == customer.id);
        if (idToUpdate == null)
            throw new DalIdNotFoundException("customer id not found");
        XElement customerToUpdate = idToUpdate.Parent;
        customerToUpdate.Element(NAME).SetValue(customer.name);
        customerToUpdate.Element(ADDRESS).SetValue(customer.address);
        customerToUpdate.Element(PHONE_NUMBER).SetValue(customer.phone_number);
        customersXml.Save(FILE_PATH);
    }
}
