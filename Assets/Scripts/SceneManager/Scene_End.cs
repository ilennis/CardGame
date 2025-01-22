using UnityEngine.UI;

public class Scene_End : Scene_Base
{
    public int attempts;
    public int success;
    public Text TryCountTxt;
    public Text SuccessCountTxt;
    public void Start()
    {
        attempts = GameManager.Instance.Attempts;
        success = GameManager.Instance.Success;
        TryCountTxt.text = attempts.ToString();
        SuccessCountTxt.text = success.ToString();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}