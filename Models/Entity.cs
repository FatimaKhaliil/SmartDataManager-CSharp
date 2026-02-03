namespace SmartDataManager.Models
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        protected Entity(int id)
        {
            Id = id;
        }

        public virtual string GetInfo()
        {
            return $"Entity #{Id}";
        }
    }
}
