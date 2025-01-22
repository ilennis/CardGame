public class Scene_Main : Scene_Base
{
    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Start()
    {
        AudioManager.Instance.Play("Music_Main");
        GameManager.Instance.IsEnded = false;
    }
}