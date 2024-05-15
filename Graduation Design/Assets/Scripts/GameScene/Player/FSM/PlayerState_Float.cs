using QZGameFramework.AutoUIManager;
using QZGameFramework.GFEventCenter;
using QZGameFramework.MusicManager;
using QZGameFramework.ObjectPoolManager;
using UnityEngine;

public class PlayerState_Float : PlayerState
{
    public Vector3 floatingPosition;

    public override void Init()
    {
        base.Init();
        animationName = "Float";
        animationTransitionTime = 0;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        //MusicMgr.Instance.PlaySoundMusic("univ0001", path: "Music/Sound/Player/");

        floatingPosition = transform.position + player.floatingPositionOffset;
        GameObject vfxObj = PoolMgr.Instance.GetObj("VFX_Floating", "Prefabs/VFX");
        vfxObj.transform.position = transform.position + new Vector3(transform.localScale.x * player.floatingVfxOffset.x, player.floatingVfxOffset.y);
        vfxObj.transform.SetParent(transform);

        EventCenter.Instance.EventTrigger(E_EventType.PlayerDefeated);
        UIManager.Instance.ShowWindow<DefeatWindow>();
    }

    public override void OnUpdate()
    {
        if (Vector3.Distance(transform.position, floatingPosition) > player.floatingSpeed * Time.deltaTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, floatingPosition, player.floatingSpeed * Time.deltaTime);
        }
        else
        {
            floatingPosition += (Vector3)Random.insideUnitCircle;
        }
    }

    public override void OnFixedUpdate()
    {
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}