using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

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

            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome do produto não pode ser vazio");
            }

            if (salePrice < 0)
            {
                throw new ArgumentException("O preço do produto não pode ser negativo");
            }

            if (costPrice < 0)
            {
                throw new ArgumentException("O preço de custo não pode ser negativo");
            }

            if (quantity < 0)
            {
                throw new ArgumentException("A quantidade não pode ser negativa");
            }

            if (minStock < 0)
            {
                throw new ArgumentException("O estoque mínimo não pode ser negativo");
            }

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
    }
}
