using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openForRabbit : MonoBehaviour
{
    public turningWheelCS[] w;
    public interfacer interfacerScript;
    int val(int i)
    {
        return w[i].currentNumber;
    }
    void Start()
    {

    }

    // Update is called once per frames
    void Update()
    {
        if (val(0) == 5)
        {
            interfacerScript.CanActive = true;

            for (int i = 0; i < w.Length; i++)
            {
                w[i].transform.SetParent(interfacerScript.transform, true);
                w[i].canActive = false;
            }
        }
    }
}
