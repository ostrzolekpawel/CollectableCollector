namespace OsirisGames.CollectableCollector
{
    public interface ICollector<in TData, in TView>
    {
        void Collect(TData data, TView view);
    }
}
