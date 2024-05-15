using Cysharp.Threading.Tasks;
using QZGameFramework.GFEventCenter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBall : MonoBehaviour
{
    [SerializeField] private float delayTime = 10f;

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener(E_EventType.BlackBallDestory, DestroyBlackBall);
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener(E_EventType.BlackBallDestory, DestroyBlackBall);
    }

    private void DestroyBlackBall()
    {
        DestroyBlackBallUniTask().Forget();
    }

    private async UniTaskVoid DestroyBlackBallUniTask()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(delayTime));
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<PlayerObject>(out PlayerObject player))
        {
            player.Defeated();
        }
    }
}