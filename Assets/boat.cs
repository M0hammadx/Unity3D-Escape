using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    public GameObject player;

    void Activate()
    {
        player.transform.SetParent(transform, true);
        Destroy(GetComponent<interfacer>());
        transform.Find("SelectGUI").gameObject.SetActive(false);
        //Play the leaving animation
        GetComponent<Animation>().Play();
        GetComponent<AudioSource>().Play();
    }
    void Dactivate()
    {
        player.transform.SetParent(null);
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
