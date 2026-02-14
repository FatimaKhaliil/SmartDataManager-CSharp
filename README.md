

# 🚀 SmartDataManager-CSharp

---

## 📌 Projektübersicht

Dieses Projekt ist eine **objektorientierte Konsolenanwendung in C#** zur Verwaltung von Produkten.

Es wurde im Rahmen der Prüfungsaufgabe des Moduls
**„Programmieren mit C#“** entwickelt und erfüllt alle geforderten technischen Anforderungen.

Die Anwendung ermöglicht das:

* Anlegen
* Anzeigen
* Suchen
* Ändern
* Löschen
* Sortieren

von Produkten über ein textbasiertes Konsolenmenü.

---

## 🎯 Gewähltes Szenario

### **Szenario B – Smart Data Manager**

Verwaltung eines Datensatzes (Produkte) mit vollständigen **CRUD-Operationen inklusive Sortierlogik**.

---

## ⚙️ Funktionalität

Über ein interaktives Konsolenmenü können folgende Aktionen durchgeführt werden:

* ➕ Produkt hinzufügen
* 📋 Alle Produkte anzeigen
* 🔍 Produkt anhand der ID suchen
* ✏️ Produktdaten ändern
* ❌ Produkt löschen
* 🔤 Produkte nach Name sortieren
* 💲 Produkte nach Preis sortieren
* 🚪 Programm beenden

---

# 🏗 Architektur und Aufbau

Die Anwendung ist in mehrere logisch getrennte Schichten strukturiert.

---

## 📍 Program.cs

* Einstiegspunkt der Anwendung
* Initialisiert den `ProductService`
* Steuert die Menülogik
* Verarbeitet Benutzereingaben

---

## 🧠 Services – `ProductService`

* Enthält die gesamte Geschäftslogik
* Verwaltet alle Produkte
* Implementiert CRUD-Operationen
* Implementiert Sortieroperationen:

  * `SortByName()`
  * `SortByPrice()`
* Nutzt die eigene verkettete Liste zur Datenspeicherung

---

## 🗂 Data – Eigene verkettete Liste

Zur Speicherung wird eine **selbst implementierte generische, einfach verkettete Liste** verwendet.

### Bestandteile:

* `Node<T>` – Repräsentiert ein einzelnes Element
* `MyLinkedList<T>` – Eigene generische Listenstruktur

### Wichtige Methoden:

* `AddLast`
* `TryFind`
* `ForEach`
* `RemoveFirstMatch`
* `Sort(Comparison<T>)`

Die Sortierung erfolgt innerhalb der Liste mithilfe eines generischen
`Comparison<T>`-Delegates (Bubble-Sort-Algorithmus durch Tauschen der Werte).

> Es wird **keine `List<T>` aus dem .NET-Framework** verwendet.

---

## 📦 Models

### 🔹 `Entity`

* Basisklasse mit der Eigenschaft `Id`

### 🔹 `Product` (erbt von `Entity`)

Eigenschaften:

* `Name`
* `Price`

Validierungslogik:

* Kein leerer Name erlaubt
* Kein negativer Preis erlaubt

Die Methode `GetInfo()` wird überschrieben (Polymorphie).

---

# ✅ Erfüllte Pflichtanforderungen

✔ Vererbung und Polymorphie (`Entity → Product`)
✔ Properties mit Logik (Validierung in Get/Set)
✔ Eigene dynamische Datenstruktur (verkettete Liste)
✔ Generische Typen (`MyLinkedList<T>`)

---

# ⭐ Wahlpflichtfeatures (2 von 3)

## 1️⃣ Delegates

Verwendete Delegate-Typen:

* `Func<T, bool>` → Such- und Löschoperationen
* `Action<T>` → Iteration und Ausgabe
* `Comparison<T>` → Flexible Sortierlogik

Einsatz in:

* `TryFind`
* `RemoveFirstMatch`
* `Sort`

---

## 2️⃣ Parameter-Modifikator `out`

Verwendung des `out`-Parameters in:

* `TryFind`
* `TryGetById`
* `RemoveFirstMatch`

---

# 🧩 Technische Besonderheiten

* Vollständig selbst implementierte Datenstruktur
* Flexible Sortierlogik durch Delegates
* Klare Trennung von Präsentations-, Service- und Datenebene
* Speicherung ausschließlich im Arbeitsspeicher
* Objektorientierte, modulare Architektur

---

# ▶️ Ausführung des Projekts

## Voraussetzungen

* .NET SDK (Version 8 oder höher)

## Anwendung starten

```bash
dotnet run
```

---


