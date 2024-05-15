using QZGameFramework.GFEventCenter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGate : MonoBehaviour
{
    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener(E_EventType.LevelStart, OpenStartGate);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener(E_EventType.LevelStart, OpenStartGate);
    }

    private void OpenStartGate()
    {
        this.gameObject.SetActive(false);
    }
}