namespace _Scripts.Utilities.Events.Listeners
{
    public interface IListener<in T>
    {
        public void Raise(T item);
    }
}