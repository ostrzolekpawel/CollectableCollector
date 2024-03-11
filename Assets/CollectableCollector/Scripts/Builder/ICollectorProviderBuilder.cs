using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface ICollectorProviderBuilder<TType, TData, TView, in TOptions>
    {
        UniTask<ICollectorProvider<TType, TData, TView>> Build(TOptions options);
    }
}
