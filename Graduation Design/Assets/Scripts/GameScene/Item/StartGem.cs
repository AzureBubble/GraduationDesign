using Cysharp.Threading.Tasks;
using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGem : MonoBehaviour
{
    [SerializeField] private float resetTime = 3.0f;
    private Collider coll;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerObject>(out PlayerObject player))
        {
            GameObject sfxObj = PoolMgr.Instance.GetObj("VFX_PickupStar", "Prefabs/VFX");
            sfxObj.transform.position = this.transform.position;
            MusicMgr.Instance.PlaySoundMusic("SFX_PickupStar");
            player.CanAirJump = true;
            meshRenderer.enabled = false;
            coll.enabled = false;

            DelayReset().Forget();
        }
    }

    private void Reset()
    {
        meshRenderer.enabled = true;
        coll.enabled = true;
    }

    private async UniTaskVoid DelayReset()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(resetTime));

        Reset();
    }
}