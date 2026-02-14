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
            var name = ReadRequiredText("Name: ", "Name darf nicht leer sein.");

            if (!TryReadDecimal("Preis: ", "Ungültiger Preis.", out var price))
            {
                break;
            }

            var created = service.Add(name, price);
            Console.WriteLine("Erstellt: " + created.GetInfo());
            break;

        case "2":
            service.PrintAll();
            break;

        case "3":
            if (!TryReadInt("ID: ", "Ungültige ID.", out var idFind))
            {
                break;
            }

            if (service.TryGetById(idFind, out var found) && found != null)
                Console.WriteLine("Gefunden: " + found.GetInfo());
            else
                Console.WriteLine("Nicht gefunden.");
            break;

        case "4":
            if (!TryReadInt("ID: ", "Ungültige ID.", out var idUpdate))
            {
                break;
            }

            var newName = ReadRequiredText("Neuer Name: ", "Name darf nicht leer sein.");

            if (!TryReadDecimal("Neuer Preis: ", "Ungültiger Preis.", out var newPrice))
            {
                break;
            }

            Console.WriteLine(service.Update(idUpdate, newName, newPrice)
                ? "Aktualisiert."
                : "Nicht gefunden.");
            break;

        case "5":
            if (!TryReadInt("ID: ", "Ungültige ID.", out var idDel))
            {
                break;
            }

            Console.WriteLine(service.Delete(idDel, out var removed) && removed != null
                ? "Gelöscht: " + removed.GetInfo()
                : "Nicht gefunden.");
            break;
        case "6":
            service.SortByPrice();
            Console.WriteLine("Sorted by price.");
            break;

        case "7":
            service.SortByName();
            Console.WriteLine("Sorted by name.");
            break;


        case "0":
            return;

        default:
            Console.WriteLine("Ungültige Auswahl.");
            break;
    }
}

static string ReadRequiredText(string prompt, string errorMessage)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
            return input.Trim();

        Console.WriteLine(errorMessage);
    }
}

static bool TryReadInt(string prompt, string errorMessage, out int value)
{
    Console.Write(prompt);
    if (!int.TryParse(Console.ReadLine(), out value))
    {
        Console.WriteLine(errorMessage);
        return false;
    }

    return true;
}

static bool TryReadDecimal(string prompt, string errorMessage, out decimal value)
{
    Console.Write(prompt);
    if (!decimal.TryParse(Console.ReadLine(), out value))
    {
        Console.WriteLine(errorMessage);
        return false;
    }

    return true;
}
