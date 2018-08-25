using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoBoatCondition : MonoBehaviour
{

    public CoinCollector coinScript;
    public interfacer interfacerScript;
    public int coinsTarget = 3;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("checkCoins", 0, 10);
    }
    void checkCoins()
    {
        if (coinScript.coins >= coinsTarget)
        {
            interfacerScript.CanActive = true;
            CancelInvoke("checkCoins");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
