using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCoins : MonoBehaviour
{
    [SerializeField] private List<PickableItem> _listCoins;

    [SerializeField] private Text _coinsCount;

    public int CoinsCount { get; private set; }    

    public void Init()
    {
        CoinsCount = _listCoins.Count;

        SetCoinsID();

        SwitchOnAllCoins();

        RefreshView(CoinsCount);
    }

    private void SwitchOnAllCoins()
    {
        foreach (PickableItem item in _listCoins)
        {
            item.transform.gameObject.SetActive(true);
        }
    }

    private void SetCoinsID()
    {
        int id = 0;

        foreach (PickableItem item in _listCoins)
        {
            item.SetID(id);

            id += 1;
        }
    }

    public void ReduceCoinsCount(int idItemForDelete)
    {
        foreach (PickableItem item in _listCoins)
        {
            if (item.ID == idItemForDelete)
                CoinsCount -= 1;
        }

        RefreshView(CoinsCount);
    }

    private void RefreshView(int countCoins)
    {
        if (countCoins < 0)
            countCoins = 0;

        _coinsCount.text = countCoins.ToString();
    }
}
