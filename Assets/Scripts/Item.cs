using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{   
    [SerializeField] private string _nameItem;
    [SerializeField] private int _priceItem;
    [SerializeField] private TextMeshProUGUI _textItem;
    private Shop _shop;   
    private bool _isBought = false;

    public TextMeshProUGUI TextItem { get { return _textItem; }}
    public string NameItem { get { return _nameItem; } }
    public bool IsBought { get { return _isBought; } set { _isBought = value; } }


    private void Start() => _shop = FindObjectOfType<Shop>();

    public void TryBuyItem() //OnClick Event in ButtonUnity
    {
        if(!_isBought)
        {
            _shop.NameItem = _nameItem;
            _shop.PriceItem = _priceItem;
            _shop.SoldItem();
            SaveLoad.Save();
        }
    }
}
