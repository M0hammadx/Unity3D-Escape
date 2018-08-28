using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWhenPercent : MonoBehaviour
{
    public turningWheelCS w, ww;
    public interfacer interfacerScript;

    void Update()
    {
        if (w.currentNumber == 5 && ww.currentNumber == 8)
        {
            interfacerScript.CanActive = true;
            w.transform.SetParent(interfacerScript.transform, true);
            ww.transform.SetParent(interfacerScript.transform, true);
        }
    }

}
