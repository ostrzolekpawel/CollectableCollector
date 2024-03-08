using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OsirisGames.CollectableCollector
{
    public abstract class ViewDataProvider<TType, TData, TView> : IViewDataProvider<TType, TData, TView>
    {
        private readonly Dictionary<TType, IViewData<TData, TView>> _map;

        public ViewDataProvider()
        {
            _map = new Dictionary<TType, IViewData<TData, TView>>();
        }

        public void Add(TType type, IViewData<TData, TView> viewData)
        {
            if (_map.ContainsKey(type))
            {
                throw new ArgumentException($"Element with type [{type}] aleady exist in map");
            }
            _map.Add(type, viewData);
        }

        public UniTask<TView> GetViewData(TType type, TData data)
        {
            if (_map.ContainsKey(type))
            {
                return _map[type].GetViewData(data);
            }

            throw new InvalidOperationException($"No provider found for reward type: {type}");
        }
    }
}
