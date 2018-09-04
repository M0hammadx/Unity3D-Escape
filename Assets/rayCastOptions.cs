using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using Valve.VR.InteractionSystem;
public class rayCastOptions : MonoBehaviour
{
    public LayerMask buttonsLayer;
    public TextMesh start, options, quit;
    public GameObject showText;

    RaycastHit hit;
    Hand hand;
    LineRenderer line;
    // Use this for initialization
    void Start()
    {
        hand = GetComponent<Hand>();
        line = GetComponent<LineRenderer>();
    }
    string action = null;
    bool textUp;
    // Update is called once per frame
    void Update()
    {
        if (hand.GetStandardInteractionButton())
        {
            Debug.Log("inCasting");
            if (textUp)
            {
                showText.SetActive(false);
                textUp = false;
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, 1000, buttonsLayer))
            {
                line.SetPosition(1, Vector3.forward * hit.distance);

                action = hit.collider.gameObject.name;
                if (action == "Play Game")
                {
                    start.color = Color.cyan;
                }
                else if (action == "Options")
                {
                    options.color = Color.cyan;
                }
                else if (action == "Quit")
                {
                    quit.color = Color.cyan;
                    Debug.Log(quit.color);
                }
            }
            else
            {
                line.SetPosition(1, Vector3.forward * 10000);
                action = null;
                start.color = Color.white;
                options.color = Color.white;
                quit.color = Color.white;
            }
        }
        else
        {
            line.SetPosition(1, Vector3.zero);
        }
        if (hand.GetStandardInteractionButtonUp() && textUp == false)
        {
            if (action == null) return;

            if (action == "Play Game")
            {
                EditorSceneManager.LoadScene(1);
            }
            else if (action == "Options")
            {
                textUp = true;
                showText.SetActive(true);
            }
            else if (action == "Quit")
            {
                Application.Quit();
            }
            action = null;
        }
    }
}
