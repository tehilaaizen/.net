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
        public List<Customer> ReadAll()
        {
            if (DataSource.customers == null)
                return null;
            return new List<Customer>(DataSource.customers);
        }
        public void Update(Customer customer)
        {
            if (DataSource.customers != null)
            {
                foreach (Customer c in DataSource.customers)
                {
                    if (customer != null && customer.id == c.id)
                    {
                        DataSource.customers.Remove(c);
                        DataSource.customers.Add(customer);
                        return;
                    }

                }
                throw new DalIdNotFoundException("customer not found");
            }
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
