using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface ICollectorProviderBuilder<TType, TData, TArgs, in TOptions>
    {
        UniTask<ICollectorProvider<TType, TData, TArgs>> Build(TOptions options);
    }
}
