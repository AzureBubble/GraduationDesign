using QZGameFramework.GFEventCenter;
using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitoryGem : MonoBehaviour
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
        EventCenter.Instance.EventTrigger(E_EventType.Victory);
        GameObject sfxObj = PoolMgr.Instance.GetObj("VFX_PickupHeart", "Prefabs/VFX");
        sfxObj.transform.position = transform.position;
        MusicMgr.Instance.PlaySoundMusic("SFX_PickupGem");
        meshRenderer.enabled = false;
        coll.enabled = false;
    }
}