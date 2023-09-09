using DG.Tweening;
using UnityEngine;

public class PopupTextTweener : MonoBehaviour
{
    public Ease easeType;
    public float duration;
    public float endScale;
    public float moveUp;

    private void Start()
    {
        transform.DOScale(Vector3.one * endScale, duration).SetEase(easeType);
        transform.DOMove(transform.position + Vector3.up * moveUp, duration).SetEase(easeType);
    }
}
