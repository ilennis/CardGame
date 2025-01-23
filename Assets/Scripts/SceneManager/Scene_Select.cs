public class Scene_Select : Scene_Base
{
    protected override void Initialize()
    {
        base.Initialize();
    }

    private void Start()
    {
        AudioManager.Instance.Play("Music_Title");
    }
}