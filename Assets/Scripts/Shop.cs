using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private GameObject[] _allItem;
    private string _nameItem;
    private int _priceItem;

    public string NameItem { get { return _nameItem; } set { _nameItem = value; } }
    public int PriceItem { get { return _priceItem; } set { _priceItem = value; } }


    private void Start()
    {
        SaveLoad.Load();
        if (PlayerPrefs.HasKey("Save"))
            _textMeshPro.text = SaveLoad.Data.money.ToString();
        else
        {
            SaveLoad.Data.money = 5000;
            _textMeshPro.text = SaveLoad.Data.money.ToString();
            SaveLoad.Save();
        }
        CheckBoughtItems();
    }


    private void CheckBoughtItems()
    {
        for (int i = 0; i < SaveLoad.Data.buyItem.Count; i++)
        {
            for(int y = 0; y < _allItem.Length; y++)
            {
                if (_allItem[y].GetComponent<Item>().NameItem == SaveLoad.Data.buyItem[i])
                {
                    _allItem[y].GetComponent<Item>().TextItem.text = "Bought";
                    _allItem[y].GetComponent<Item>().IsBought = true;
                }
            }
        }
    }

    public void SoldItem()
    {
        if(SaveLoad.Data.money >= _priceItem)
        {          
            SaveLoad.Data.buyItem.Add(_nameItem);
            SaveLoad.Data.money = SaveLoad.Data.money - _priceItem;
            _textMeshPro.text = SaveLoad.Data.money.ToString();
            CheckBoughtItems();
        }
    }
}
