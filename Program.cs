using StockManager.Services;
using StockManager.UI;

namespace StockManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var menu = new Menu(new StockService());
            menu.Run();
        }
    }
}
