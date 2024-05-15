using Cysharp.Threading.Tasks;
using QZGameFramework.AutoUIManager;
using QZGameFramework.GFEventCenter;
using QZGameFramework.GFInputManager;
using QZGameFramework.ObjectPoolManager;
using QZGameFramework.PersistenceDataMgr;
using QZGameFramework.StateMachine;
using QZGameFramework.Utilities;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    private BaseFsm fsm;
    private float horizontal;
    private Rigidbody rb;
    private PlayerGroundCheck groundCheck;
    private PlayerInfo playerInfo;
    public bool IsMove => horizontal != 0;
    public bool IsJump { get; set; }
    public bool StopJump { get; set; }
    public float MoveSpeed => Mathf.Abs(rb.velocity.x);
    public bool IsGrounded => groundCheck.IsGrounded;
    public bool IsFalling => !IsGrounded && rb.velocity.y < 0;
    public bool CanAirJump { get; set; }
    public bool HasJumpInputBuffer { get; set; }
    public bool Victory { get; private set; }
    public bool Dead { get; set; }

    public bool isDebugTest;
    public float runSpeed;
    public float jumpSpeed;
    public float airJumpSpeed;
    public float acceleration = 5f;
    public float deceleration = 5f;
    public float stiffTime = 0.2f;
    public float coyoteTime = 0.1f;
    public float jumpInputBufferTime = 0.5f;
    public float floatingSpeed = 0.5f;
    public Vector3 floatingVfxOffset;
    public Vector3 floatingPositionOffset;

    public AnimationCurve speedCurve;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        groundCheck = this.GetComponentInChildren<PlayerGroundCheck>();
        InitPlayerInfo();
        InitFsm();
    }

    private void OnEnable()
    {
        //InputMgr.Instance.Enable();

        InputMgr.Instance.RegisterCommand("Horizontal", KeyPressType.AxisRaw, GetHorizontalValue);
        InputMgr.Instance.RegisterCommand(KeyCode.Space, KeyPressType.Down, SetJump);
        InputMgr.Instance.RegisterCommand(KeyCode.Space, KeyPressType.Up, SetStopJump);

        EventCenter.Instance.AddEventListener(E_EventType.Victory, PlayerVictory);
        EventCenter.Instance.AddEventListener(E_EventType.LevelStart, LevelStart);
    }

    private void Update()
    {
        fsm.Update();
    }

    private void FixedUpdate()
    {
        fsm.FixedUpdate();
    }

    private void OnDisable()
    {
        InputMgr.Instance.Disable();

        InputMgr.Instance.RemoveCommand("Horizontal", KeyPressType.AxisRaw, GetHorizontalValue);
        InputMgr.Instance.RemoveCommand(KeyCode.Space, KeyPressType.Down, SetJump);
        InputMgr.Instance.RemoveCommand(KeyCode.Space, KeyPressType.Up, SetStopJump);
        EventCenter.Instance.RemoveEventListener(E_EventType.Victory, PlayerVictory);
        EventCenter.Instance.RemoveEventListener(E_EventType.LevelStart, LevelStart);
    }

    private void InitPlayerInfo()
    {
        playerInfo = BinaryDataMgr.Instance.GetTable<PlayerInfoContainer>().dataDic[1];
        //List<float> bornPosFloatArr = StringConvert.StringToValue<float>(playerInfo.bornPos, ',');
        Vector3 bornPos = StringConvert.StringToValueVector3(playerInfo.bornPos, ',');

        this.transform.position = bornPos;

        runSpeed = playerInfo.runSpeed;
        jumpSpeed = playerInfo.jumpSpeed;
        airJumpSpeed = playerInfo.airJumpSpeed;
        acceleration = playerInfo.acceleration;
        deceleration = playerInfo.deceleration;
        stiffTime = playerInfo.stiffTime;
        coyoteTime = playerInfo.coyoteTime;
        jumpInputBufferTime = playerInfo.jumpInputBufferTime;
        floatingSpeed = playerInfo.floatingSpeed;
    }

    private void InitFsm()
    {
        if (fsm == null)
        {
            fsm = new BaseFsm(this.gameObject);
        }

        fsm.AddState<PlayerState_Idle>();
        fsm.AddState<PlayerState_Run>();
        fsm.AddState<PlayerState_Jump>();
        fsm.AddState<PlayerState_Fall>();
        fsm.AddState<PlayerState_Land>();
        fsm.AddState<PlayerState_Victory>();
        fsm.AddState<PlayerState_AirJump>();
        fsm.AddState<PlayerState_CoyoteTime>();
        fsm.AddState<PlayerState_Defeat>();
        fsm.AddState<PlayerState_Float>();

        fsm.StateOn<PlayerState_Idle>();
    }

    private void LevelStart()
    {
        InputMgr.Instance.Enable();
    }

    public void Defeated()
    {
        InputMgr.Instance.Disable();
        SetVelocity(Vector3.zero);
        SetUseGravity(false);
        rb.detectCollisions = false;
        Dead = true;
    }

    private void PlayerVictory()
    {
        SetVelocity(Vector3.zero);
        InputMgr.Instance.Disable();

        Victory = true;
        //Debug.Log("Victory");
    }

    private void SetStopJump(KeyCode keyCode)
    {
        StopJump = true;
        IsJump = false;
        HasJumpInputBuffer = false;
    }

    private void GetHorizontalValue(float h)
    {
        horizontal = h;
    }

    private void SetJump(KeyCode keyCode)
    {
        StopJump = false;
        IsJump = true;
    }

    public void FlipTo()
    {
        if (IsMove)
        {
            this.transform.localScale = new Vector3(horizontal, 1, 1);
        }
    }

    public void Move(float speed)
    {
        FlipTo();
        SetVelocityX(speed * horizontal);
    }

    public void Jump(float jumpSpeed)
    {
        IsJump = false;
        SetVelocityY(jumpSpeed);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector3(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector3(rb.velocity.x, velocityY);
    }

    public void SetUseGravity(bool isOn)
    {
        rb.useGravity = isOn;
    }

    public async UniTaskVoid JumpInputBufferAsync()
    {
        HasJumpInputBuffer = true;
        await UniTask.Delay(TimeSpan.FromSeconds(jumpInputBufferTime));
        HasJumpInputBuffer = false;
        IsJump = false;
    }

#if UNITY_EDITOR

    private void OnGUI()
    {
        if (isDebugTest)
        {
            Rect rect = new Rect(10, 10, 200, 20);
            string message = "Has Jump Input Buffer: " + HasJumpInputBuffer;
            GUIStyle style = new GUIStyle();
            style.fontSize = 20;
            style.fontStyle = FontStyle.Bold;
            GUI.Label(rect, message, style);
            rect = new Rect(10, 40, 200, 20);
            message = "IsJump: " + IsJump;
            style = new GUIStyle();
            style.fontSize = 20;
            style.fontStyle = FontStyle.Bold;
            GUI.Label(rect, message, style);
        }
    }

#endif
}