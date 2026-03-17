using DalApi;
using DO;

namespace Dal
{
    internal class CustomerImplementation:Icustomer
    {
        public int Create(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException();
            foreach (Customer c in DataSource.customers)
            {
                if (c != null && c.id == customer.id)
                    throw new DalIdAlreadyExistsException("create customer id:" + customer.id + " already exsists");
            }
            DataSource.customers.Add(customer);
            return customer.id;

        }
        public Customer? Read(int id)
        {
            if (DataSource.customers != null)
            {
                foreach (Customer customer in DataSource.customers)
                {
                    if (customer != null && customer.id == id)
                        return customer;
                }
            }
            throw new DalIdNotFoundException("customer not found");
        }
        public Customer? Read(Func<Customer, bool> filter)
        {
            if (DataSource.customers == null)
                return null;
            return DataSource.customers.FirstOrDefault(filter);
        }
        public List<Customer?> ReadAll(Func<Customer,bool>?filter)
        {
            if (DataSource.customers == null)
                return null;
            if (filter == null)
                return DataSource.customers.ToList();
            return DataSource.customers.Where(filter).ToList();
        }
        public void Update(Customer customer)
        {
            Delete(customer.id);
            DataSource.customers.Add(customer);          
        }
        public void Delete(int id)
        {
            if (DataSource.customers != null)
            {
                foreach (Customer c in DataSource.customers)
                {
                    if (c != null && c.id == id)
                    {
                        DataSource.customers.Remove(c);
                        return;
                    }
                }
                throw new DalIdNotFoundException("customer not found");
            }

        }
    }
}
