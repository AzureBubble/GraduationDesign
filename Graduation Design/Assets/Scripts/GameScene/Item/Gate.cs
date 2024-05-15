using QZGameFramework.GFEventCenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener(E_EventType.OpenGate, OpenGate);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener(E_EventType.OpenGate, OpenGate);
    }

    private void OpenGate()
    {
        this.gameObject.SetActive(false);
    }
}