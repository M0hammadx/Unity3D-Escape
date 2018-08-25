using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceTryMove : MonoBehaviour
{
    jigsaw jigsawScript;

    private void Start()
    {
        jigsawScript = transform.parent.gameObject.GetComponent<jigsaw>();
    }

    void Activate()
    {
        //Debug.Log("click");
        jigsawScript.tryMove(transform);
    }
}
