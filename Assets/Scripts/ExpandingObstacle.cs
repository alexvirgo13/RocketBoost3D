using UnityEngine;
using DG.Tweening;

public class ExpandingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 axis = new Vector3(0, 3, 0);
    [SerializeField] private float duration = 2.0f;
    [SerializeField] private float delay = 0f;

    void Start ()
    {
        transform.DOScale(transform.localScale + axis, duration)
            .SetLink(gameObject)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(delay);
    }
}
