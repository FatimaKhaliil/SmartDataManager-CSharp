namespace SmartDataManager.Data
{
    public class Node<T> // generische Node-Klasse für die verkettete Liste
    {
        public T Value { get; set; }  //typischerweise enthält eine Node einen Wert und einen Verweis auf die nächste Node
        public Node<T>? Next { get; set; } // nullable, da die letzte Node keinen Nachfolger hat

        public Node(T value) // Konstruktor, der den Wert der Node setzt
        {
            Value = value;
        }
    }
}
