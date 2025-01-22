using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimeText : MonoBehaviour
{
    private RectTransform rectTransform;
    private Sequence sequence;
    private Text time;
    private int second;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        sequence = DOTween.Sequence().SetAutoKill(false)
            .Append(rectTransform.DOPunchScale(0.2f * Vector2.one, 0.2f));

        time = GetComponent<Text>();
    }

    private void Update()
    {
        var time = float.Parse(this.time.text);
        var second = Mathf.FloorToInt(time);
        if (second == this.second)
        {
            return;
        }
        this.second = second;

        sequence.Restart();
        AudioManager.Instance.Play("SoundFX_ClockTicking");
    }

    private void OnDestroy()
    {
        sequence.Kill();
    }
}