using QZGameFramework.MusicManager;
using UnityEngine;

public class SoundDestory : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (audioSource != null && !audioSource.isPlaying)
        //{
        //    MusicMgr.Instance.StopSoundMusic(audioSource);
        //}
    }
}