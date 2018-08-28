using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openForSevenUp : MonoBehaviour
{

    public turningWheelCS[] w;
    public interfacer interfacerScript;
    int sum;
    HashSet<int> set = new HashSet<int>();
    // Update is called once per frame
    void Update()
    {
        if (CheckForWin())
        {
            interfacerScript.CanActive = true;

            for (int i = 0; i < w.Length; i++)
            {
                w[i].transform.SetParent(interfacerScript.transform, true);
                w[i].canActive = false;
            }
        }
    }
    int val(int i)
    {
        return w[i].currentNumber;
    }
    int val(int a, int b, int c)
    {
        return val(a) + val(b) + val(c);
    }
    bool CheckForWin()
    {
        set = new HashSet<int>();
        for (int i = 0; i < w.Length; i++)
        {
            set.Add(val(i));
        }
        if (set.Count != w.Length) return false;
        if (val(0, 1, 2) != 0 && val(0, 1, 2) == val(0, 3, 4) && val(0, 1, 2) == val(0, 5, 6))
            return true;
        return false;

    }
}
