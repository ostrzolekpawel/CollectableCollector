using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface IViewDataProvider<in TType, TData, TViewData>
    {
        void Add(TType type, IViewData<TData, TViewData> viewData);
        void GetViewData(TType type, TData data);
        UniTask<TViewData> GetViewDataAsync(TType type, TData data);
    }
}
