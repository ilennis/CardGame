using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public Button OffBtn;
    public GameObject Panel;
    public GameObject BackBtn;
    public GameObject Nextpanel;

    private void Awake()
    {
        AudioManager.Instance.Play("SoundFX_Lock");
    }

    public void Notion_OFF()
    {
        Panel.SetActive(false);
    }

    public void BackTxt()
    {
        Nextpanel.SetActive(true);
        Panel.SetActive(false);
    }
}
