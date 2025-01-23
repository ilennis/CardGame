using System.Diagnostics;
using UnityEngine.UI;

public enum CHARACTER
{
    DongYoung = 0,
    HyeJin = 1,
    DongHoon = 2,
    HanNa = 3,
    SeokHo = 4
}

public class Scene_Hidden : Scene_Base
{
    /*
    public hiddenCharacter DongYoung;
    public hiddenCharacter HyeJin;
    public hiddenCharacter DongHoon;
    public hiddenCharacter HanNa;
    public hiddenCharacter SeokHo;
    */

    public HiddenCharacter[] characters;
    public HiddenCards[] cards;

    public Hidden_StageButton stageButton;
    public Hidden_TitleButton titleButton;

    public SpeechBubble bubble;

    public Text titleText;

    public int whoseTurn;
    public int turnCount;
    public float speed = 1.0f;

    public bool isEnd = false;


    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Start()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.Play("Music_Hidden");

        whoseTurn = 0;
        turnCount = 0;

        characters[whoseTurn].isMyTurn = true;
        characters[whoseTurn].isGoing = true;

        isEnd = false;
        speed = 1.0f;
    }

    private void Update()
    {
        //if (isEnd)
        //{
        //    stageButton.gameObject.SetActive(true);
        //    titleButton.gameObject.SetActive(true);
        //    isEnd = false;
        //}

    }

}