using StockManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockManager.Services
{
    public class StockService
    {
        /// <summary>
        /// Propriedade apenas para a leitura externa dos produtos em estoque
        /// </summary>
        public IReadOnlyCollection<Product> AllProducts => Products.Values;
        private Dictionary<string, Product> Products { get; } = new();
        private List<StockMovement> Movements { get; } = new();
        private int LastId { get; set; } //Guarda o id do ultimo registro de movimentações do estoque


        public StockService() { }
       
        //Registro para primeira entrada de um produto
        public void Register(Product product)
        {
            if (Products.ContainsKey(product.Code))
            {
                throw new InvalidOperationException("Um produto de mesmo código já está cadastrado no estoque");
            }

            Products.Add(product.Code, product);
            Movements.Add(new StockMovement(GetNewMovementId(), product.Code, MovementType.FirstEntry, product.Quantity, DateTime.Now));
        }

        public void RegisterStockEntry(Product product, int quantity)
        {
            product.AddStock(quantity);
            Movements.Add(new StockMovement(GetNewMovementId(), product.Code, MovementType.Entry, quantity, DateTime.Now));
        }

        public void RegisterStockExit(Product product, int quantity)
        {
            product.RemoveStock(quantity);
            Movements.Add(new StockMovement(GetNewMovementId(), product.Code, MovementType.Adjustment, quantity, DateTime.Now));
        }
        
        private int GetNewMovementId()
        {
            return ++LastId;
        }
    }
}
