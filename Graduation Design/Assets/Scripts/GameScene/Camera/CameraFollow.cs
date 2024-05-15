using Cinemachine;
using QZGameFramework.GFEventCenter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineStateDrivenCamera stateDrivenCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        stateDrivenCamera = this.GetComponent<CinemachineStateDrivenCamera>();
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener<Transform>(E_EventType.PlayerInstantiate, Follow);
    }

    private void Follow(Transform target)
    {
        if (virtualCamera != null)
            virtualCamera.Follow = target;
        if (stateDrivenCamera != null)
        {
            stateDrivenCamera.Follow = target;
            stateDrivenCamera.m_AnimatedTarget = target.GetComponentInChildren<Animator>();
        }
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener<Transform>(E_EventType.PlayerInstantiate, Follow);
    }
}