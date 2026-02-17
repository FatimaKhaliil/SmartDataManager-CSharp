namespace SmartDataManager.Models
{
    public abstract class Entity   // abstrakte Basisklasse für alle Entitäten, die eine ID haben
    {
        public int Id { get; protected set; }   //  ID-Eigenschaft, die von abgeleiteten Klassen gesetzt werden kann, aber nicht von außen

        protected Entity(int id)  //    Konstruktor, der die ID setzt, wird von abgeleiteten Klassen aufgerufen
        {
            Id = id;
        }

         public virtual string GetInfo() // virtuelle Methode, die von abgeleiteten Klassen überschrieben werden kann, um spezifische Informationen zurückzugeben
        {
            return $"Entity #{Id}";
        }
    }
}
    