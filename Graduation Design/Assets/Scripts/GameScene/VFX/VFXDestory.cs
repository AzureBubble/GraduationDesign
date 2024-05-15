using QZGameFramework.ObjectPoolManager;
using UnityEngine;

public class VFXDestory : MonoBehaviour
{
    private ParticleSystem particle;

    private void Awake()
    {
        particle = this.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (particle != null && !particle.isPlaying)
        {
            string objectName = gameObject.name.Replace("(Clone)", "");
            PoolMgr.Instance.RealeaseObj(objectName, this.gameObject);
        }
    }
}