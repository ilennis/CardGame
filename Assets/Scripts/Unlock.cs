using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public Button OffBtn;
    public GameObject Panel;

    private void OnEnable()
    {
        AudioManager.Instance.Play("SoundFX_Lock");
    }

    public void Notion_OFF()
    {
        Panel.SetActive(false);
    }
}