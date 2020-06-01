namespace FrameworkGoat
{
    public interface IObserver
    {
        void OnNotify(params object[] parameters);
    }

    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }
}