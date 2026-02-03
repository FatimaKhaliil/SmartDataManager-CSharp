# SmartDataManager-CSharp

## Projektübersicht
Dieses Projekt ist eine Konsolenanwendung in C#, die zur Verwaltung von Produkten dient.  
Es wurde im Rahmen der Prüfungsaufgabe des Moduls **„Programmieren mit C#“** entwickelt und erfüllt alle geforderten technischen Anforderungen.

Die Anwendung ermöglicht das **Anlegen, Anzeigen, Suchen, Ändern und Löschen** von Produkten über ein textbasiertes Menü in der Konsole.

---

## Gewähltes Szenario
**Szenario B – Smart Data Manager**

Verwaltung eines Datensatzes (Produkte) mit vollständigen CRUD-Operationen.

---

## Funktionalität
Über ein interaktives Konsolenmenü können folgende Aktionen durchgeführt werden:

- Produkt hinzufügen
- Alle Produkte anzeigen
- Produkt anhand der ID suchen
- Produktdaten ändern
- Produkt löschen
- Programm beenden

---

## Architektur und Aufbau

### Program.cs
- Einstiegspunkt der Anwendung
- Initialisiert den `ProductService`
- Steuert die Menülogik und Benutzereingaben

### Services – ProductService
- Enthält die Geschäftslogik
- Verwaltet Produkte
- Implementiert CRUD-Operationen
- Verwendet eine eigene verkettete Liste zur Datenspeicherung

### Data – Eigene verkettete Liste
- `Node<T>`: Repräsentiert ein einzelnes Element
- `MyLinkedList<T>`: Eigene generische, einfach verkettete Liste
- Wichtige Methoden:
  - `AddLast`
  - `TryFind`
  - `ForEach`
  - `RemoveFirstMatch`
- Es wird **keine `List<T>` aus dem .NET-Framework** verwendet

### Models
- `Entity`: Basisklasse mit der Eigenschaft `Id`
- `Product`: Erbt von `Entity`
  - Eigenschaften: `Name`, `Price`
  - Validierung (kein leerer Name, kein negativer Preis)
  - Überschreibt `GetInfo()` zur textuellen Darstellung

---

## Erfüllte Pflichtanforderungen

- ✔ Vererbung und Polymorphie (`Entity` → `Product`)
- ✔ Properties mit Logik (Validierung in Get/Set)
- ✔ Eigene dynamische Datenstruktur (verkettete Liste)
- ✔ Generische Typen (`MyLinkedList<T>`)

---

## Wahlpflichtfeatures (2 von 3)

1. **Delegates**
   - `Func<T, bool>` für Such- und Löschoperationen
   - `Action<T>` für die Ausgabe aller Elemente

2. **Parameter-Modifikator `out`**
   - Verwendung in `TryFind`
   - Verwendung in `TryGetById`

---

## Ausführung des Projekts

### Voraussetzungen
- .NET SDK (Version 8 oder höher)

### Starten der Anwendung
```bash
dotnet run
