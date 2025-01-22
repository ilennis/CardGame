using DG.Tweening;
using UnityEngine;

public class UI_Warning : MonoBehaviour
{
    private RectTransform rectTransform;
    private Sequence sequence;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        sequence = DOTween.Sequence().SetLoops(-1)
            .Append(rectTransform.DOPunchRotation(2.0f * Vector3.one, 0.5f).SetDelay(0.5f));
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}