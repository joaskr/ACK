using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ISaveManager
{
    public static PlayerManager instance;
    public Player player;
    public int currency;
   

    private void Awake()
    {
        if(instance!=null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
    public int GetCurrency() => currency;


    public void SaveData(ref GameData _data)
    {
        this.currency = _data.currency;
    }
    public void LoadData(GameData _data)
    {
        _data.currency = this.currency;
    }
    public bool HaveEnoughMoney(int _price)
    {
        if(_price > currency)
        {
            return false;
        }
        currency = currency - _price;
        return true;
    }
    public int getCurrentCurrency()
    {
        return currency;
    }
}
