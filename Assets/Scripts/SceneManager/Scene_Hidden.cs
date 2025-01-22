public class Scene_Hidden : Scene_Base
{
    public hiddenCharacter DongYoung;
    public hiddenCharacter HyeJin;
    public hiddenCharacter DongHoon;
    public hiddenCharacter HanNa;
    public hiddenCharacter SeokHo;

    public int turnNumber;

    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Start()
    {
        AudioManager.Instance.Play("Music_Hidden");

        turnNumber = 0;
    }

    private void Update()
    {
        
    }
}