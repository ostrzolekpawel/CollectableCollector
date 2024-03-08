namespace OsirisGames.CollectableCollector
{
    public interface ICollector<in TData, in TView>
    {
        void Collect(TData reward, TView view);
    }
}
