using DG.Tweening;
using UnityEngine;

public class UI_TouchHere : MonoBehaviour
{
    private RectTransform rectTransform;
    private Sequence sequence;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        sequence = DOTween.Sequence().SetLoops(-1)
            .Append(rectTransform.DOPunchScale(0.2f * Vector2.one, 0.1f).SetDelay(0.8f));
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}