using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFromPentagon : MonoBehaviour
{

    public turningWheelCS[] w;
    public interfacer interfacerScript;
    int cnt;
    void Update()
    {
        cnt = 0;
        for (int i = 0; i < 5; i++)
        {
            if (w[i].currentNumber == i + 1)
            {
                cnt++;
            }

        }
        if (cnt == 3 && w[1].currentNumber == 5 && w[4].currentNumber == 2)
        {
            cnt++;
            cnt++;
        }
        if (cnt == 5)
        {
            interfacerScript.CanActive = true;

            for (int i = 0; i < 5; i++)
            {
                w[i].transform.SetParent(interfacerScript.transform, true);
                w[i].canActive = false;
            }
        }
    }
}
