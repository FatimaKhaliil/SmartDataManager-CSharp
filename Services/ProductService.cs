using System;
using SmartDataManager.Data; //use the MyLinkedList class from the Data namespace
using SmartDataManager.Models;//use the Product class from the Models namespace

namespace SmartDataManager.Services
{
    public class ProductService
    {
        private readonly MyLinkedList<Product> _products = new(); // Interne Liste zur Speicherung der Produkte, die eine verkettete Liste von Product-Objekten ist. Diese Liste ermöglicht das Hinzufügen, Entfernen, Suchen und Sortieren von Produkten.
        private int _nextId = 1;

        public int Count => _products.Count;

        // Create
        public Product Add(string name, decimal price)
        {
            var p = new Product(_nextId++, name, price);  //var bedeutet hier, dass der Compiler den Typ des Produkts automatisch anhand des Konstruktors der Product-Klasse ableitet. Das Produkt wird mit einer eindeutigen ID (die automatisch inkrementiert wird), einem Namen und einem Preis erstellt.
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

            _products.ForEach(p => Console.WriteLine(p.GetInfo()));// Ausgabe aller Produkte, indem die GetInfo-Methode jedes Produkts aufgerufen wird
        }


        public bool TryGetById(int id, out Product? product) // Methode zum Suchen eines Produkts anhand seiner ID, gibt true zurück, wenn das Produkt gefunden wurde, und false, wenn nicht. Das gefundene Produkt wird über den out-Parameter zurückgegeben
        {
            return _products.TryFind(p => p.Id == id, out product);
            //warum out? weil wir das gefundene Produkt zurückgeben wollen, wenn es gefunden wird. TryFind gibt true zurück, wenn ein Produkt mit der angegebenen ID gefunden wurde, und false, wenn nicht. Das gefundene Produkt wird über den out-Parameter zurückgegeben.
        }

        // Update
        public bool Update(int id, string newName, decimal newPrice)
        {
            if (!_products.TryFind(p => p.Id == id, out var p) || p == null)
                return false;

            p.Name = newName; // Aktualisieren des Namens des gefundenen Produkts
            p.Price = newPrice;// Aktualisieren des Preises des gefundenen Produkts
            return true; // Rückgabe von true, um anzuzeigen, dass das Produkt erfolgreich aktualisiert wurde
        }

        // Delete
        public bool Delete(int id, out Product? removed)
        {
            return _products.RemoveFirstMatch(p => p.Id == id, out removed);
            // Wenn ein Produkt gefunden und entfernt wird, wird true zurückgegeben, und das gelöschte Produkt wird über den out-Parameter zurückgegeben.
        }
        // Sort by price
        public void SortByPrice()  //  sortiert die interne Liste der Produkte basierend auf dem Preis jedes Produkts in aufsteigender Reihenfolge
        {
            _products.Sort((a, b) => a.Price.CompareTo(b.Price));
        }
        // Sort by name
        public void SortByName() //  sortiert die interne Liste der Produkte basierend auf dem Namen jedes Produkts in alphabetischer Reihenfolge
        {
            _products.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.CurrentCultureIgnoreCase));
        }
      /*   public int CountByPrice(decimal minPrice)
        {
            int count = 0;

            _products.ForEach(p =>
            {
                if (p.Price >= minPrice)
                    count++;
            });

            return count;
        }
 */        public void SortById()
        {
            _products.Sort((a, b) => a.Id.CompareTo(b.Id));
        }


    }



}
