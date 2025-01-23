using UnityEngine;
using UnityEngine.UI;

public class Scene_Main : Scene_Base
{
    public Canvas MainUI;

    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Start()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.Play("Music_Main");

        var parent = MainUI.transform;
        int index = 0;
        GameManager.Instance.timeTxt = parent.GetChild(index++).GetComponent<Text>();
        GameManager.Instance.warning = parent.GetChild(index++).GetComponent<Text>();
        GameManager.Instance.Match = parent.GetChild(index++).GetComponent<Animator>();
        GameManager.Instance.Nomatch = parent.GetChild(index++).GetComponent<Animator>();
    }
}