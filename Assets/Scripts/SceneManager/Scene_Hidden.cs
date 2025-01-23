using System.Diagnostics;

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

    public hiddenCharacter[] characters;
    public HiddenCards[] cards;

    public SpeechBubble bubble;

    public int whoseTurn;
    public float speed = 1.0f;


    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Start()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.Play("Music_Hidden");

        //whoseTurn = (int)CHARACTER.DongYoung; // 0
        //characters[whoseTurn].isMyTurn = true;
        //speed = 1.0f;

        whoseTurn = 0;
        characters[whoseTurn].isMyTurn = true;
        characters[whoseTurn].isGoing = true;

    }

    private void Update()
    {
        

        
    }
}