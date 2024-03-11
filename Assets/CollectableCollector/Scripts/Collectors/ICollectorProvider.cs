using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableCollector
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TType">type of data</typeparam>
    /// <typeparam name="TData">data</typeparam>
    /// <typeparam name="TView">view which will provided further for animation purposes or other</typeparam>
    public interface ICollectorProvider<in TType, TData, TView>
    {
        void Add(TType type, ICollector<TData, TView> collector);
        void Collect(TType type, TData reward, TView view);
        UniTask CollectAsync(TType type, TData reward, TView view);
    }
}
