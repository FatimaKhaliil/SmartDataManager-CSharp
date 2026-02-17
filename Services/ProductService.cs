using System;
using SmartDataManager.Data;
using SmartDataManager.Models;

namespace SmartDataManager.Services
{
    public class ProductService
    {
        private readonly MyLinkedList<Product> _products = new(); // interne Liste zur Verwaltung der Produkte
        private int _nextId = 1;  // Hilfsvariable zur Vergabe eindeutiger IDs, wird bei jedem neuen Produkt inkrementiert

        public int Count => _products.Count; // öffentliche Eigenschaft, um die Anzahl der Produkte zu erhalten

        // Create
        public Product Add(string name, decimal price) // Methode zum Hinzufügen eines neuen Produkts, nimmt Name und Preis als Parameter entgegen
        {
            var p = new Product(_nextId++, name, price);  // Erstellen eines neuen Produkts mit der nächsten verfügbaren ID, Name und Preis
            _products.AddLast(p); // Hinzufügen des neuen Produkts zur internen Liste
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

            _products.ForEach(p => Console.WriteLine(p.GetInfo()));// Ausgabe aller Produkte, indem die GetInfo-Methode jedes Produkts aufgerufen wird
        }

        // Read (by id) -> out
        public bool TryGetById(int id, out Product? product) // Methode zum Suchen eines Produkts anhand seiner ID, gibt true zurück, wenn das Produkt gefunden wurde, und false, wenn nicht. Das gefundene Produkt wird über den out-Parameter zurückgegeben
        {
            return _products.TryFind(p => p.Id == id, out product);//warum out? weil wir das gefundene Produkt zurückgeben wollen, wenn es gefunden wird. TryFind gibt true zurück, wenn ein Produkt mit der angegebenen ID gefunden wurde, und false, wenn nicht. Das gefundene Produkt wird über den out-Parameter zurückgegeben.
        }

        // Update
        public bool Update(int id, string newName, decimal newPrice) // Methode zum Aktualisieren eines Produkts anhand seiner ID, nimmt die ID des zu aktualisierenden Produkts sowie den neuen Namen und Preis als Parameter entgegen. Gibt true zurück, wenn das Produkt erfolgreich aktualisiert wurde, und false, wenn kein Produkt mit der angegebenen ID gefunden wurde.
        {
            if (!_products.TryFind(p => p.Id == id, out var p) || p == null) // Suchen des Produkts mit der angegebenen ID. Wenn kein Produkt gefunden wird, wird false zurückgegeben.
                return false;

            p.Name = newName; // Aktualisieren des Namens des gefundenen Produkts
            p.Price = newPrice;// Aktualisieren des Preises des gefundenen Produkts
            return true; // Rückgabe von true, um anzuzeigen, dass das Produkt erfolgreich aktualisiert wurde
        }

        // Delete
        public bool Delete(int id, out Product? removed) // Methode zum Löschen eines Produkts anhand seiner ID, nimmt die ID des zu löschenden Produkts als Parameter entgegen. Gibt true zurück, wenn das Produkt erfolgreich gelöscht wurde, und false, wenn kein Produkt mit der angegebenen ID gefunden wurde. Das gelöschte Produkt wird über den out-Parameter zurückgegeben.
        {
            return _products.RemoveFirstMatch(p => p.Id == id, out removed);// Suchen und Entfernen des Produkts mit der angegebenen ID. Wenn ein Produkt gefunden und entfernt wird, wird true zurückgegeben, und das gelöschte Produkt wird über den out-Parameter zurückgegeben. Wenn kein Produkt mit der angegebenen ID gefunden wird, wird false zurückgegeben, und der out-Parameter enthält null.
        }
        // Sort by price
        public void SortByPrice()  // Methode zum Sortieren der Produkte nach Preis, sortiert die interne Liste der Produkte basierend auf dem Preis jedes Produkts in aufsteigender Reihenfolge
        {
            _products.Sort((a, b) => a.Price.CompareTo(b.Price));
        }
        // Sort by name
        public void SortByName() // Methode zum Sortieren der Produkte nach Name, sortiert die interne Liste der Produkte basierend auf dem Namen jedes Produkts in alphabetischer Reihenfolge
        {
            _products.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCultureIgnoreCase));
        }



    }
}
