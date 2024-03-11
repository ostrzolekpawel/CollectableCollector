using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public  interface IViewDataProviderBuilder<TType, TData, TView, in TOptions>
    {
        UniTask<IViewDataProvider<TType, TData, TView>> Build(TOptions options);
    }
}
