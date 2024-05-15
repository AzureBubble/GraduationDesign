using Cysharp.Threading.Tasks;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }

    //private void Start()
    //{
    //    WaitUntilCondition().Forget();
    //}

    //private async UniTaskVoid WaitUntilCondition()
    //{
    //    while (true)
    //    {
    //        await UniTask.Yield();

    //        RotateObject();
    //    }
    //}

    //private void RotateObject()
    //{
    //    transform.Rotate(rotation * Time.deltaTime);
    //}
}