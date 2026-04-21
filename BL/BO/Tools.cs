using DO;
using System.Reflection;
namespace BO;

internal static class Tools
{
    public static string ToStringProperty<T>(this T t)
    {
        return "";
    }
    public static Customer ToDOCustomer(this DO.Customer customer)
    {
        return new Customer();
    }

}
