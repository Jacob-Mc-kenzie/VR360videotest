using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Controller : MonoBehaviour
{

    SteamVR_Action_Boolean m_uppress, m_downpress, m_leftpress, m_rightpress;
    SteamVR_Action_Vector2 m_touchPos;

    private void Awake()
    {
        m_uppress = SteamVR_Actions._default.TapTop;

        m_touchPos = SteamVR_Actions._default.TouchTouchpad;

        #region event binding
        m_uppress[SteamVR_Input_Sources.Any].onStateDown += UpPressAction;

        m_touchPos[SteamVR_Input_Sources.Any].onAxis += Controller_onAxis;
        #endregion
    }

   

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions._default.Teleport.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Teleport down");
        }

        if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            Debug.Log("Grab pinch up");
        }
    }

    private void UpPressAction(SteamVR_Action_Boolean action, SteamVR_Input_Sources source)
    {
        Debug.Log($"User pressed up on {source.ToString()}");
    }
    private void Controller_onAxis(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        Debug.Log($"User is touching point {axis.x}, {axis.y} : {delta.x}, {delta.y}");
    }
}
