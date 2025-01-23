using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hidden_StageButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void OnClick()
    {
        AudioManager.Instance.StopMusic();
        SceneManager.LoadScene("0. TitleScene");
    }
}
