using System;

namespace SmartDataManager.Models//namespace  bezieht sich auf den Ordner, in dem die Klasse liegt
{
    public class Product : Entity     // produkt erbt von entity, damit wir die id haben
    {
        private string _name = string.Empty;   // initialisieren mit leerem string, damit wir nicht null haben
        private decimal _price;   // decimal ist besser für Geldbeträge, da es keine Rundungsfehler hat

        public string Name // Eigenschaft für den Namen des Produkts
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))   // Überprüfen, ob der Name leer oder nur aus Leerzeichen besteht
                    throw new ArgumentException("Name darf nicht leer sein.");
                _name = value.Trim();
            }
        }

        public decimal Price // Eigenschaft für den Preis des Produkts   decimal ist besser für Geldbeträge, da es keine Rundungsfehler hat
        {
            get => _price;
            set
            {
                if (value < 0)  // Überprüfen, ob der Preis negativ ist
                    throw new ArgumentException("Preis darf nicht negativ sein.");
                _price = value;
            }
        }

        public Product(int id, string name, decimal price) : base(id)  // Konstruktor, der die ID an die Basisklasse weitergibt
        {
            Name = name;
            Price = price;
        }

        public override string GetInfo()     // Überschreiben der GetInfo-Methode, um spezifische Informationen über das Produkt zurückzugeben
        {
return $"Produkt-ID: {Id} | Produktname: {Name} | Preis: {Price:0.00} €";
        }
    }
}
