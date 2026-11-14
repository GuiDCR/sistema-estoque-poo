namespace StockManager.Models
{
    public class Product
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public int Quantity { get; private set; }
        public int MinimumStock { get; private set; }
        public string? Supplier { get; set; }
        public string? Brand { get; set; }

        public Product(string code, string name, decimal salePrice, decimal costPrice,
            int quantity, int minStock = 0, string? supplier = null, string? brand = null)
        { 

            if (String.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("O código do produto não pode ser vazio");
            }

            ValidateText(code, "Código");
            ValidateText(name, "Nome");
            ValidateNotNegative(salePrice, "Preço de venda");
            ValidateNotNegative(costPrice, "Preço de custo");
            ValidateNotNegative(quantity, "Quantidade");
            ValidateNotNegative(minStock, "Estoque mínimo");
           
            Code = code;
            Name = name;
            SalePrice = salePrice;
            CostPrice = costPrice;
            Quantity = quantity;
            MinimumStock = minStock;
            Supplier = supplier;
            Brand = brand;
        }

        public void AddStock(int qty)
        {
            if(qty <= 0)
            {
                throw new ArgumentException("A quantidade a ser adicionada não pode ser menor ou igual a zero");
            }

            Quantity += qty;
        }

        public void RemoveStock(int qty)
        {
            if(qty <= 0)
            {
                throw new ArgumentException("A quantidade a ser removida não pode ser menor ou igual a zero");
            }

            if(qty > Quantity)
            {
                throw new ArgumentException("A quantidade a ser removida não pode ser maior que a atual");
            }

            Quantity -= qty;
        }

        public static void ValidateNotNegative(decimal value, string fieldName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"O {fieldName} não pode ser negativo");
            }
        }

        public static void ValidateText(string text, string fieldName)
        {
            if (String.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"O(A) {fieldName} não pode ser vazio(a)");
            }
        }
    }
}
