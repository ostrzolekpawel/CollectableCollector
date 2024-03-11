# Collectable Collector

Abstraction layer to handle collect and display collectables.

## Implementation

### Collectable
#### ICollector

```cs
public interface ICollector<in TData, in TView>
{
    void Collect(TData data, TView view);
}
```

Implement to describe separately every collectable element how it should be collected.

Example implementation:
```cs
public class RewardView : MonoBehaviour, IRewardView
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _value;

    public Image ValueImage => _icon;
    public TextMeshProUGUI ValueText => _value;
}

public class GoldCollector : ICollectableCollector<Collectable, IRewardView>
{
    private readonly CurrencyDecorator _currencyDecorator;

    public GoldRewardViewCollector(CurrencyDecorator currencyDecorator)
    {
        _currencyDecorator = currencyDecorator;
    }

    public void Collect(Collectable reward, IRewardView view) // animations etc should be seprated
    {
        _currencyDecorator.AddGold(reward.Value);
    }
}
```

#### ICollectorProvider
Implement to gather information about all `ICollector` implementations.
Returns correct implementation based on provided type.

Provided example and ready to use and inherit from solution

```cs
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
}
```

### ViewData