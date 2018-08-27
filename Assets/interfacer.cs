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
        // Debug.Log("sent");
        gameObject.SendMessage("Activate");
    }
    bool canPress = true;
    private void HandHoverUpdate(Hand hand)
    {
        if (CanActive && hand.GetStandardInteractionButtonDown())
        {
            sendActive();
            Debug.Log("AWDA");
        }
        if (CanActive && hand.GetStandardInteractionButtonUp())
        {
            SendMessage("Deactivate");
        }

        //if (CanActive && hand.GetStandardInteractionButtonDown() || (canPress && (hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)))
        //{
        //    sendActive();
        //    canPress = false;
        //}
        //if ((hand.controller != null) && !hand.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
        //{
        //    canPress = true;
        //}
        //if (CanActive && hand.GetStandardInteractionButtonUp() || ((hand.controller != null) && hand.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger)))
        //{
        //    SendMessage("Deactivate");
        //}
    }
}

