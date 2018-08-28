using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openOnWin : MonoBehaviour
{
    public jigsaw jigsawScript;
    public interfacer interfacerScript;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (jigsawScript.Won) interfacerScript.CanActive = true;
    }
}
