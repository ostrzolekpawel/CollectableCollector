using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OsirisGames.CollectableCollector
{
    public abstract class CollectorProvider<TType, TData, TView> : ICollectorProvider<TType, TData, TView>
    {
        private readonly Dictionary<TType, ICollector<TData, TView>> _map;

        public CollectorProvider()
        {
            _map = new Dictionary<TType, ICollector<TData, TView>>();
        }

        public void Add(TType type, ICollector<TData, TView> collector)
        {
            if (_map.ContainsKey(type))
            {
                throw new ArgumentException($"Element with type [{type}] aleady exist in map");
            }
            _map.Add(type, collector);
        }

        public void Collect(TType type, TData data, TView view)
        {
            if (_map.ContainsKey(type))
            {
                _map[type].Collect(data, view);
                return;
            }

            throw new InvalidOperationException($"No provider found for type: {type}");
        }

        public async UniTask CollectAsync(TType type, TData data, TView view)
        {
            if (_map.ContainsKey(type))
            {
                await _map[type].CollectAsync(data, view);
            }

            throw new InvalidOperationException($"No provider found for type: {type}");
        }
    }
}
