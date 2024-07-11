using Cysharp.Threading.Tasks;

namespace OsirisGames.CollectableHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TType">type of data</typeparam>
    /// <typeparam name="TData">data</typeparam>
    /// <typeparam name="TArgs">Additional information for collecting, e.g. animations etcr</typeparam>
    public interface ICollectorProvider<in TType, TData, TArgs>
    {
        void Add(TType type, ICollector<TData, TArgs> collector);
        void Collect(TType type, TData reward, TArgs args = default);
        UniTask CollectAsync(TType type, TData reward, TArgs args = default);
    }
}
