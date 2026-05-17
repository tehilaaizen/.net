using DalApi;
using DO;

namespace Dal
{
    internal class ProductImplementation : IProduct
    {
        public int Create(Product product)
        {
            Product product1 = product with { id = DataSource.Config.Product_id };
            DataSource.products.Add(product1);
            return product1.id;

        }
        public Product? Read(int id)
        {
            if (DataSource.products != null)
            {
                foreach (Product product in DataSource.products)
                {
                    if (product != null && product.id == id)
                        return product;
                }
            }
            throw new DalIdNotFoundException("product not found");
        }
        public Product? Read(Func<Product, bool> filter)
        {
            if(DataSource.products == null) 
                return null;
            return DataSource.products.FirstOrDefault(filter);
        }
        public List<Product?> ReadAll(Func<Product,bool>?filter=null)
        {
            if (DataSource.products == null)
                return null;
            if (filter == null)
                return DataSource.products.ToList();
            return DataSource.products.Where(filter).ToList();
        }
        public void Update(Product product)
        {
            Delete(product.id);
            DataSource.products.Add(product);
        }
        public void Delete(int id)
        {
            if (DataSource.products != null)
            {
                foreach (Product p in DataSource.products)
                {
                    if (p != null && p.id == id)
                    {
                        DataSource.products.Remove(p);
                        return;
                    }
                }
                throw new DalIdNotFoundException("product not found");
            }

        }
    }
}
