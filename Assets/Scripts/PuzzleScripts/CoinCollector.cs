﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinCollector : MonoBehaviour
{
    
    public AudioClip CoinSound = null;
    private AudioSource mAudioSource = null;
    public int coins;

    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("in");
        if (other.gameObject.tag.Equals("Coin"))
        {
            if (mAudioSource != null && CoinSound != null)
            {
                mAudioSource.PlayOneShot(CoinSound);
            }
            coins++;
            Destroy(other.gameObject);
        }
    }
}