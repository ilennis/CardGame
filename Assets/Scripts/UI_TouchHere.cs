using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_TouchHere : MonoBehaviour
{
    public int clickCount = 0;

    private RectTransform rectTransform;
    private Sequence sequence;

    public MiniCharacters characters;
    public UI_Title title;

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

    public void HiddenClick()
    {
        clickCount++;
        AudioManager.Instance.Play("SoundFX_StartButton");
        AudioManager.Instance.StopMusic();

        if (clickCount >= 10)
        {
            characters.Jump();
            title.Death();
            SceneManager.LoadScene(1);
        }
    }
}