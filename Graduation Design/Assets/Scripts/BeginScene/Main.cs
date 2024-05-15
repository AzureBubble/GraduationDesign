using QZGameFramework.AutoUIManager;
using QZGameFramework.PackageMgr.ResourcesManager;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.ShowWindow<BeginWindow>();

        UIManager.Instance.PreLoadWindow<SettingWindow>();
        UIManager.Instance.PreLoadWindow<AboutWindow>();
        UIManager.Instance.PreLoadWindow<LoadingWindow>();
    }
}