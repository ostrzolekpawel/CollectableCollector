using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OsirisGames.CollectableHandler
{
    public abstract class ViewDataProvider<TType, TData, TViewData> : IViewDataProvider<TType, TData, TViewData>
    {
        private readonly Dictionary<TType, IViewData<TData, TViewData>> _map;

        public ViewDataProvider()
        {
            _map = new Dictionary<TType, IViewData<TData, TViewData>>();
        }

        public void Add(TType type, IViewData<TData, TViewData> viewData)
        {
            if (_map.ContainsKey(type))
            {
                throw new ArgumentException($"Element with type [{type}] aleady exist in map");
            }
            _map.Add(type, viewData);
        }

        public void GetViewData(TType type, TData data)
        {
            if (_map.ContainsKey(type))
            {
                _map[type].GetViewData(data);
            }

            throw new InvalidOperationException($"No provider found for type: {type}");
        }

        public async UniTask<TViewData> GetViewDataAsync(TType type, TData data)
        {
            if (_map.ContainsKey(type))
            {
                return await _map[type].GetViewDataAsync(data);
            }

            throw new InvalidOperationException($"No provider found for type: {type}");
        }
    }
}
