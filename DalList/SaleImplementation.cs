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
        public Sale? Read(Func<Sale, bool> filter)
        {
            if(DataSource.sales == null) 
                return null;
            return DataSource.sales.FirstOrDefault(filter);
        }
        public List<Sale?>? ReadAll(Func<Sale,bool>?filter)
        {
            if (DataSource.sales == null)
                return null;
            if(filter == null)
                return DataSource.sales.ToList();
            return DataSource.sales.Where(filter).ToList();
        }
        public void Update(Sale sale)
        {
            Delete(sale.id);
            DataSource.sales.Add(sale);
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
