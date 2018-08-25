using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{

    void Activate()
    {
        Destroy(GetComponent<interfacer>());
        transform.Find("SelectGUI").gameObject.SetActive(false);
        //Play the leaving animation
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
