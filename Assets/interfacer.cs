using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class interfacer : MonoBehaviour
{
    public bool CanActive = true;
    private void OnHandHoverBegin()
    {
        enableGUI();
    }


    //-------------------------------------------------
    private void OnHandHoverEnd()
    {
        disableGUI();
    }

    public void disableGUI()
    {

        if (CanActive && gameObject.transform.Find("SelectGUI"))
            gameObject.transform.Find("SelectGUI").gameObject.SetActive(false);
    }
    public void enableGUI()
    {
        if (CanActive && gameObject.transform.Find("SelectGUI"))
            gameObject.transform.Find("SelectGUI").gameObject.SetActive(true);//Set the selected gui to be visable
    }
    public void sendActive()
    {
        Debug.Log("sent");
        gameObject.SendMessage("Activate");
    }
    private void HandHoverUpdate(Hand hand)
    {

        if (CanActive && hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)))
        {
            sendActive();
        }
    }
}

