using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface IViewDataProvider<in TType, TData, TView>
    {
        void Add(TType type, IViewData<TData, TView> viewData);
        void GetViewData(TType type, TData data);
        UniTask<TView> GetViewDataAsync(TType type, TData data);
    }
}
