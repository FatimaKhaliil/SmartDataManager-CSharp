using System;
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
    Console.WriteLine("6) Nach Preis sortieren");
    Console.WriteLine("7) Nach Name sortieren");
    Console.WriteLine("8) Nach ID sortieren");
/*     Console.WriteLine("9) Anzahl Produkte nach Preis");
 */    Console.WriteLine("0) Beenden");
    Console.Write("Auswahl: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
        {
            try
            {
                var name = ReadRequiredText("Name: ", "Name darf nicht leer sein.");
                var price = ReadRequiredDecimalNonNegative("Preis: ");

                var created = service.Add(name, price);
                Console.WriteLine("Erstellt: " + created.GetInfo());
            }
            catch (ArgumentException ex)
            {
                // Falls Model-Validierung trotzdem eine Exception wirft
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler: " + ex.Message);
            }

            break;
        }

        case "2":
            service.PrintAll();
            break;

        case "3":
        {
            try
            {
                var idFind = ReadRequiredInt("ID: ", "Ungültige ID.");
                if (service.TryGetById(idFind, out var found) && found != null)
                    Console.WriteLine("Gefunden: " + found.GetInfo());
                else
                    Console.WriteLine("Nicht gefunden.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler: " + ex.Message);
            }

            break;
        }

        case "4":
        {
            try
            {
                var idUpdate = ReadRequiredInt("ID: ", "Ungültige ID.");
                var newName = ReadRequiredText("Neuer Name: ", "Name darf nicht leer sein.");
                var newPrice = ReadRequiredDecimalNonNegative("Neuer Preis: ");

                Console.WriteLine(service.Update(idUpdate, newName, newPrice)
                    ? "Aktualisiert."
                    : "Nicht gefunden.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler: " + ex.Message);
            }

            break;
        }

        case "5":
        {
            try
            {
                var idDel = ReadRequiredInt("ID: ", "Ungültige ID.");

                Console.WriteLine(service.Delete(idDel, out var removed) && removed != null
                    ? "Gelöscht: " + removed.GetInfo()
                    : "Nicht gefunden.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unerwarteter Fehler: " + ex.Message);
            }

            break;
        }

        case "6":
            service.SortByPrice();
            Console.WriteLine("Nach Preis sortiert:");
            service.PrintAll();
            break;

        case "7":
            service.SortByName();
            Console.WriteLine("Nach Name sortiert:");
            service.PrintAll();
            break;

            case "8":
    service.SortById();
    Console.WriteLine("Produkte nach ID sortiert.");
    service.PrintAll();
    break;


  /*   case "9":
    var minPrice = ReadRequiredDecimalNonNegative("Mindestpreis: ");
    var count = service.CountByPrice(minPrice);
    Console.WriteLine($"Anzahl Produkte mit Preis >= {minPrice}: {count}"); 
    service.CountByPrice(minPrice);
    break;
 */

        case "0":
            return;

        default:
            Console.WriteLine("Ungültige Auswahl.");
            break;
    }
}

// ------------------------------------
// Helper Methoden (Eingabe-Validierung)
// ------------------------------------

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


static int ReadRequiredInt(string prompt, string errorMessage) // ID muss Zahl sein (und fragt so lange neu)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();

        if (int.TryParse(input, out var value))
            return value;

        Console.WriteLine(errorMessage);
    }
}

// Preis muss Zahl UND >= 0 sein (und fragt so lange neu)
static decimal ReadRequiredDecimalNonNegative(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();

        if (!decimal.TryParse(input, out var value))
        {
            Console.WriteLine("Ungültiger Preis. Bitte Zahl eingeben.");
            continue;
        }

        if (value < 0)
        {
            Console.WriteLine("Preis darf nicht negativ sein.");
            continue;
        }

        return value;
    }
}
