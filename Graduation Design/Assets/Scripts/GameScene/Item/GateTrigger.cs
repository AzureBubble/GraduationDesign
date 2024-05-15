using QZGameFramework.GFEventCenter;
using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    private Collider coll;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        EventCenter.Instance.EventTrigger(E_EventType.BlackBallDestory);
        EventCenter.Instance.EventTrigger(E_EventType.OpenGate);
        GameObject sfxObj = PoolMgr.Instance.GetObj("VFX_Diamond", "Prefabs/VFX");
        sfxObj.transform.position = transform.position;
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupGate");
        meshRenderer.enabled = false;
        coll.enabled = false;
    }
}