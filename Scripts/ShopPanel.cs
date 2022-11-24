using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void BuyButton1()
    {
        CashManager.instance.totalCash -= 1000;
    }
    public void BuyButton2()
    {
        CashManager.instance.totalCash -= 2000;
    }
    public void BuyButton3()
    {
        CashManager.instance.totalCash -= 3000;
    }
}
