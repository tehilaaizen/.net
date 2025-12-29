using DalApi;
using DO;
namespace Dal
{
    internal class SaleImplementation:Isale
    {
        public int Create(Sale sale)
        {
            Sale sale1 = sale with { id = DataSource.Config.Sale_id };
            DataSource.sales.Add(sale1);
            return sale1.id;

        }
        public Sale? Read(int id)
        {
            if (DataSource.sales != null)
            {
                foreach (Sale sale in DataSource.sales)
                {
                    if (sale != null && sale.id == id)
                        return sale;
                }
            }
            throw new DalIdNotFoundException("sale not found");
        }
        public List<Sale> ReadAll()
        {
            if (DataSource.sales == null)
                return null;
            return new List<Sale>(DataSource.sales);
        }
        public void Update(Sale sale)
        {
            if (DataSource.sales != null)
            {
                foreach (Sale s in DataSource.sales)
                {
                    if (sale != null && sale.id == s.id)
                    {
                        DataSource.sales.Remove(s);
                        DataSource.sales.Add(sale);
                        return;
                    }

                }
                throw new DalIdNotFoundException("sales not found");
            }
        }
        public void Delete(int id)
        {
            if (DataSource.sales != null)
            {
                foreach (Sale s in DataSource.sales)
                {
                    if (s != null && s.id == id)
                    {
                        DataSource.sales.Remove(s);
                        return;
                    }
                }
                throw new DalIdNotFoundException("sale not found");
            }
        }
    }
}
