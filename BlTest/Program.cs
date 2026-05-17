using BlApi;

namespace BlTest
{
    internal class Program
    {
    static private IBl s_bl = BlApi.Factory.Get;
        static void Main(string[] args)
        {
            DalTest.Initialization.Initialize();
        }
    }
}
