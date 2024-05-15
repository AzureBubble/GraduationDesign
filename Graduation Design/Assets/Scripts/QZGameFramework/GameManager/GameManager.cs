using QZGameFramework.AutoUIManager;
using QZGameFramework.GFEventCenter;
using QZGameFramework.GFInputManager;
using QZGameFramework.MusicManager;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏一开始就会创建的全局唯一的游戏管理器
/// 如有需要初始化的脚本、数据等，可以在这里进行初始化
/// </summary>
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public bool IsShowEscWindow { get; set; }

    private static bool isInit = false; // 是否已经初始化过

    /// <summary>
    /// 饿汉单例:游戏运行时加载程序唯一全局单例管理器
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitalizeGameManager()
    {
        GameObject obj;
        // 已经初始化过 则不再进行初始化
        if (isInit)
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }

            Debug.LogError("GameManager Has Initialized.");
            return;
        }

        obj = new GameObject("GameManager");
        instance = obj.AddComponent<GameManager>();
        DontDestroyOnLoad(obj);

        // 游戏数据 管理器等进行初始化
        //UIManager.Instance.ShowPanel<LoginPanel>();
        //MusicMgr.Instance.PlayGameMusic("BGM");
        //MusicMgr.Instance.PlayAmbientMusic("a");
        //InputManager.Instance.PushStack();
        SingletonManager.Initialize();

        isInit = true;
    }

    private void Awake()
    {
        MusicMgr.Instance.PlayGameMusicAsync("BGM");
    }

    private void OnEnable()
    {
        EventCenter.Instance.AddEventListener(E_EventType.Victory, Victory);
        InputMgr.Instance.RegisterCommand(KeyCode.Escape, KeyPressType.Down, ShowEscWindow);
    }

    private void ShowEscWindow(KeyCode keyCode)
    {
        if (SceneManager.GetActiveScene().name == "BeginScene") return;
        IsShowEscWindow = !IsShowEscWindow;
        if (IsShowEscWindow)
        {
            UIManager.Instance.ShowWindow<EscWindow>();
        }
        else
        {
            UIManager.Instance.HideWindow<EscWindow>();
        }
    }

    private void Victory()
    {
        UIManager.Instance.ShowWindow<VictoryWindow>();
    }

    private void OnDisable()
    {
        EventCenter.Instance.RemoveEventListener(E_EventType.Victory, Victory);
        InputMgr.Instance.RemoveCommand(KeyCode.Escape, KeyPressType.Down, ShowEscWindow);
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            Destroy(this.gameObject);
        }
        instance = null;
    }
}