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

        public void Collect(TType type, TData reward, TView view)
        {
            if (_map.ContainsKey(type))
            {
                _map[type].Collect(reward, view);
                return;
            }

            throw new InvalidOperationException($"No provider found for reward type: {type}");
        }
    }
}
