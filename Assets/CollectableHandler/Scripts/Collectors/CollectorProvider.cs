using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OsirisGames.CollectableCollector
{
    public abstract class CollectorProvider<TType, TData, TArgs> : ICollectorProvider<TType, TData, TArgs>
    {
        private readonly Dictionary<TType, ICollector<TData, TArgs>> _map;

        public CollectorProvider()
        {
            _map = new Dictionary<TType, ICollector<TData, TArgs>>();
        }

        public void Add(TType type, ICollector<TData, TArgs> collector)
        {
            if (_map.ContainsKey(type))
            {
                throw new ArgumentException($"Element with type [{type}] aleady exist in map");
            }
            _map.Add(type, collector);
        }

        public void Collect(TType type, TData data, TArgs args = default)
        {
            if (_map.ContainsKey(type))
            {
                _map[type].Collect(data, args);
                return;
            }

            throw new InvalidOperationException($"No provider found for type: {type}");
        }

        public async UniTask CollectAsync(TType type, TData data, TArgs args = default)
        {
            if (_map.ContainsKey(type))
            {
                await _map[type].CollectAsync(data, args);
            }

            throw new InvalidOperationException($"No provider found for type: {type}");
        }
    }
}
