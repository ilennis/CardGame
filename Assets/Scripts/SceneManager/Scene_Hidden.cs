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

    public int whoseTurn;
    

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

        whoseTurn = 0;
        characters[whoseTurn].isMyTurn = true;
        characters[whoseTurn].isGoing = true;

    }

    private void Update()
    {
        

        
    }
}