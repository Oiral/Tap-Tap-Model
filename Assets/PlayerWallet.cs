using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour {

    public int money = 0;

    public static PlayerWallet instance;

    public int tapModifier = 1;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    public bool CanPurchase(int amount)
    {
        if (amount <= money)
            return true;
        else
            return false;
    }

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
        if (money < 0)
            money = 0;
    }

}
