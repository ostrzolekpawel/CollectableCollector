using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface IViewData<in TData, TViewData>
    {
        void GetViewData(TData data); // why it doesn't return view data?
        UniTask<TViewData> GetViewDataAsync(TData data);
    }
}
