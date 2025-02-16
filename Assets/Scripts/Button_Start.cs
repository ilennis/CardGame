using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_Start : MonoBehaviour
{
    [SerializeField]
    private Sprite pressedSprite;

    public void Pressed()
    {
        GetComponent<Button>().enabled = false;

        AudioManager.Instance.Play("SoundFX_Jump");
        DOVirtual.DelayedCall(0.66f, () => AudioManager.Instance.Play("SoundFX_StartButton"));
        DOVirtual.DelayedCall(0.8f, () =>
        {
            GetComponent<Image>().sprite = pressedSprite;
            SceneManager.LoadScene(4);
        });
    }
}