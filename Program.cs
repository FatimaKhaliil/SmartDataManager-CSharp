using SmartDataManager.Services;

var service = new ProductService();

while (true)
{
    Console.WriteLine("\n=== Smart Data Manager ===");
    Console.WriteLine("1) Produkt hinzufügen");
    Console.WriteLine("2) Alle Produkte anzeigen");
    Console.WriteLine("3) Produkt suchen (ID)");
    Console.WriteLine("4) Produkt ändern (ID)");
    Console.WriteLine("5) Produkt löschen (ID)");
    Console.WriteLine("0) Beenden");
    Console.Write("Auswahl: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Preis: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Ungültiger Preis.");
                break;
            }

            var created = service.Add(name, price);
            Console.WriteLine("Erstellt: " + created.GetInfo());
            break;

        case "2":
            service.PrintAll();
            break;

        case "3":
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out var idFind))
            {
                Console.WriteLine("Ungültige ID.");
                break;
            }

            if (service.TryGetById(idFind, out var found) && found != null)
                Console.WriteLine("Gefunden: " + found.GetInfo());
            else
                Console.WriteLine("Nicht gefunden.");
            break;

        case "4":
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out var idUpdate))
            {
                Console.WriteLine("Ungültige ID.");
                break;
            }

            Console.Write("Neuer Name: ");
            var newName = Console.ReadLine() ?? "";

            Console.Write("Neuer Preis: ");
            if (!decimal.TryParse(Console.ReadLine(), out var newPrice))
            {
                Console.WriteLine("Ungültiger Preis.");
                break;
            }

            Console.WriteLine(service.Update(idUpdate, newName, newPrice)
                ? "Aktualisiert."
                : "Nicht gefunden.");
            break;

        case "5":
            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out var idDel))
            {
                Console.WriteLine("Ungültige ID.");
                break;
            }

            Console.WriteLine(service.Delete(idDel, out var removed) && removed != null
                ? "Gelöscht: " + removed.GetInfo()
                : "Nicht gefunden.");
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Ungültige Auswahl.");
            break;
    }
}
