using StockManager.Services;

namespace StockManager.UI
{
    public class Menu
    {
        private StockService Service { get; }

        public Menu(StockService service)
        {
            Service = service;
        }

        public void Run()
        {
            int option;

            do
            {
                DisplayOptions();
                option = ReadInt();
                HandleOption(option);
            }
            while (option != 0);
        }
        private static void DisplayOptions()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma ação:");
            Console.WriteLine("(1) Consultar estoque");
            Console.WriteLine("(2) Cadastrar novo produto");
            Console.WriteLine("Movimentações de Estoque");
            Console.WriteLine("├──(3) Entrada");
            Console.WriteLine("├──(4) Saída");
            Console.WriteLine("└──(5) Ver histórico");
            Console.WriteLine();
            Console.WriteLine("(0) Sair\n");

            Console.Write("Digite o número da opção ->");
        }

        private void HandleOption(int option)
        {

            switch (option)
            {
                case 0:
                    break;
                case 1:
                    CheckStock();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        private void RegisterProduct()
        {
            

        }

        private void CheckStock()
        {
            const int width = -20;

            string header = $"{"Código", width}{"Nome", width}{"Preço de venda", width}" +
                $"{"Preço de custo", width}{"Quantidade", width}{"Fornecedor", width}{"Marca", width}";

            Console.WriteLine(header + "\n");

            foreach (var product in Service.AllProducts)
            {
                Console.WriteLine($"{product.Code, width}{product.Name,width}{product.SalePrice, width}{product.CostPrice,width}" +
                    $"{product.Quantity,width}{product.Supplier,width}{product.Brand,width}");
            }
            Console.ReadLine();
        }

        private void CheckHistory()
        {

        }

        private void StockEntry()
        {

        }

        private void StockExit()
        {

        }

        private static int ReadInt()
        {
            int value;
            string? input = Console.ReadLine();
            
            while(!int.TryParse(input, out value))
            {
                Console.WriteLine("Valor inválido. Digite apenas um número inteiro");
            }

            return value;
        }
    }
}
