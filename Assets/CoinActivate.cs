using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinActivate : MonoBehaviour
{
    public CoinCollector coinScript;

    void Start()
    {

    }

    void Activate()
    {
        if (coinScript.mAudioSource != null && coinScript.CoinSound != null)
        {
            coinScript.mAudioSource.PlayOneShot(coinScript.CoinSound);
        }
        coinScript.coins++;
        DestroyImmediate(gameObject);
    }
}
