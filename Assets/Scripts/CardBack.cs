using DG.Tweening;
using UnityEngine;

public class CardBack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Sequence sequence;
    private static Color color = Color.black;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }

    private void UpdateColor()
    {
        sequence = DOTween.Sequence().Append(spriteRenderer.DOColor(color, 1.0f).SetEase(Ease.Linear)).OnComplete(UpdateColor);
    }

    public static void SetRandomColor()
    {
        var random = Random.Range(0.0f, 0.5f);
        color = new(random, random, random);
    }
}