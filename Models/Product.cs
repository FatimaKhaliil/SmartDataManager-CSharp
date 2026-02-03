using System;

namespace SmartDataManager.Models
{
    public class Product : Entity
    {
private string _name = string.Empty;
        private decimal _price;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name darf nicht leer sein.");
                _name = value.Trim();
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Preis darf nicht negativ sein.");
                _price = value;
            }
        }

        public Product(int id, string name, decimal price) : base(id)
        {
            Name = name;
            Price = price;
        }

        public override string GetInfo()
        {
            return $"Produkt #{Id}: {Name} - {Price:0.00} €";
        }
    }
}
