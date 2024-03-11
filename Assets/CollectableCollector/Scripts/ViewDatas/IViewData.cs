using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface IViewData<in TData, TViewData>
    {
        void GetViewData(TData data);
        UniTask<TViewData> GetViewDataAsync(TData data);
    }
}
