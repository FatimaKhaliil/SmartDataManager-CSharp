using System;
using SmartDataManager.Data;
using SmartDataManager.Models;

namespace SmartDataManager.Services
{
    public class ProductService
    {
        private readonly MyLinkedList<Product> _products = new();
        private int _nextId = 1;

        public int Count => _products.Count;

        // Create
        public Product Add(string name, decimal price)
        {
            var p = new Product(_nextId++, name, price);
            _products.AddLast(p);
            return p;
        }

        // Read (all)
        public void PrintAll()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Keine Produkte vorhanden.");
                return;
            }

            _products.ForEach(p => Console.WriteLine(p.GetInfo()));
        }

        // Read (by id) -> out
        public bool TryGetById(int id, out Product? product)
        {
            return _products.TryFind(p => p.Id == id, out product);
        }

        // Update
        public bool Update(int id, string newName, decimal newPrice)
        {
            if (!_products.TryFind(p => p.Id == id, out var p) || p == null)
                return false;

            p.Name = newName;
            p.Price = newPrice;
            return true;
        }

        // Delete
        public bool Delete(int id, out Product? removed)
        {
            return _products.RemoveFirstMatch(p => p.Id == id, out removed);
        }
    }
}
