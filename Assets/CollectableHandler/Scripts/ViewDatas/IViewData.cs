using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableHandler
{
    public interface IViewData<in TData, TViewData>
    {
        TViewData GetViewData(TData data);
        UniTask<TViewData> GetViewDataAsync(TData data);
    }
}
