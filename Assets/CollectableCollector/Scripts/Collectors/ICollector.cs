using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface ICollector<in TData, in TArgs>
    {
        void Collect(TData data, TArgs args);
        UniTask CollectAsync(TData data, TArgs args);
    }
}
