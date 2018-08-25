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
        if (jigsawScript.blank_Type == jigsaw.Blank_Type.SINGLE_BLANK)
            jigsawScript.tryMoveSingle(transform);
        else if (jigsawScript.blank_Type == jigsaw.Blank_Type.MULTI_BLANK)
        {
            if (!jigsawScript.moveFrom)
            {
                jigsawScript.moveFrom = transform;
            }
        }
    }
    void Deactivate()
    {
        if (jigsawScript.blank_Type == jigsaw.Blank_Type.MULTI_BLANK)
        {
            jigsawScript.tryMoveMulti(transform);
        }

    }
}
