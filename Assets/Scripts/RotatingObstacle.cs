using UnityEngine;
using DG.Tweening;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 rotation = new Vector3(0, 360, 0);
    [SerializeField] private float duration = 2.0f;
    [SerializeField] private float delay = 0f;

    void Start ()
    {
        transform.DOLocalRotate(rotation, duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .SetDelay(delay);
    }
}
