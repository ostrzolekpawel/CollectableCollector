using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    public interface IViewData<in TData, TViewData>
    {
        UniTask<TViewData> GetViewData(TData data);
    }
}
