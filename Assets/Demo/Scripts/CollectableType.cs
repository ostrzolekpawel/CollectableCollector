using Cysharp.Threading.Tasks;
using OsirisGames.CollectableCollector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum CollectableType
{
    Money,
    Gold,
    Diamond
}

public class Collectable
{
    public int Value { get; set; }
    public CollectableType Type { get; set; }
    public string Code { get; set; }

    public Collectable(int value, CollectableType type, string code = null)
    {
        Value = value;
        Type = type;
        Code = code;
    }
}

public interface ICollectableView
{
    Image Icon { get; }
    TextMeshProUGUI Value { get; }
}

public interface ICollectableViewData
{
    Sprite Icon { get; }
    string TextFormat { get; }
}

public class CollectableViewData : ICollectableViewData
{
    public Sprite Icon { get; set; }

    public string TextFormat { get; set; }
}

public class GoldView : IViewData<Collectable, ICollectableViewData>
{
    // todo get from somewhere view data for example asset manager or som config
    public void GetViewData(Collectable data)
    {
        throw new System.NotImplementedException();
    }

    public UniTask<ICollectableViewData> GetViewDataAsync(Collectable data)
    {
        throw new System.NotImplementedException();
    }
}

public class CollectableViewProvider : ViewDataProvider<CollectableType, Collectable, ICollectableViewData>
{

}
public enum CollectableViewOptions
{
    Small,
    Medium,
    Big
}
public class CollectableViewBuilder : IViewDataProviderBuilder<CollectableType, Collectable, ICollectableViewData, CollectableViewOptions>
{
    public async UniTask<IViewDataProvider<CollectableType, Collectable, ICollectableViewData>> Build(CollectableViewOptions options)
    {
        // use options to decide when there will more possibilites
        return await Default();
    }

    private async UniTask<IViewDataProvider<CollectableType, Collectable, ICollectableViewData>> Default()
    {
        var defaultView = new CollectableViewProvider();
        defaultView.Add(CollectableType.Gold, new GoldView());
        return defaultView;
    }
}

public class CollectableView : MonoBehaviour, ICollectableView
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _value;

    public Image Icon => _icon;

    public TextMeshProUGUI Value => _value;
}

public class MoneyCollector : ICollector<Collectable, ICollectableView>
{
    private readonly CollectableManager _manager;

    public MoneyCollector(CollectableManager manager)
    {
        _manager = manager;
    }

    public void Collect(Collectable data, ICollectableView args = null)
    {
        _manager.AddGold(data.Value);
    }

    public UniTask CollectAsync(Collectable data, ICollectableView args = null)
    {
        Collect(data, args);
        return UniTask.CompletedTask;
    }
}

public class CollectableCollectorProvider : CollectorProvider<CollectableType, Collectable, ICollectableView>
{

}

public class CollectableContainer
{
    public int Money { get; set; }
    public int Gold { get; set; }
    public int Diamond { get; set; }
}

public class CollectableManager
{
    private readonly CollectableContainer _wealth;

    public CollectableManager(CollectableContainer wealth)
    {
        _wealth = wealth;
    }

    public void AddMoney(int value) => _wealth.Money += value;
    public void AddGold(int value) => _wealth.Gold += value;
    public void AddDiamond(int value) => _wealth.Diamond += value;
}