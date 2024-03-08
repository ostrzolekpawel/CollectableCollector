using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface IViewDataProvider<in TType, TData, TView>
    {
        void Add(TType type, IViewData<TData, TView> viewData);
        UniTask<TView> GetViewData(TType type, TData data);
    }
}
