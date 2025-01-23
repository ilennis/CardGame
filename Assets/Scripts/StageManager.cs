using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StageType
{
    Easy,
    Hard
}

public class StageManager : MonoBehaviour
{
    private readonly float LOADING_DELAY = 1.0f;

    public Canvas canvas;

    public bool clear = false;

    public StageType CurrentStage { get; private set; } = StageType.Easy;
    public static StageManager Instance { get; private set; }

    private bool isLoading = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SelectStage(StageType stage)
    {
        if (isLoading)
        {
            return;
        }

        isLoading = true;
        AudioManager.Instance.StopMusic();

        DOVirtual.DelayedCall(LOADING_DELAY, () =>
        {
            //하드모드일때
            if (stage == StageType.Hard)
            {
                if (clear == true)
                {
                    CurrentStage = stage;
                    SceneManager.LoadScene(1);
                }
            }
            //이지모드일 때
            else
            {
                CurrentStage = stage;
                SceneManager.LoadScene(1);
            }

            isLoading = false;
        });
    }

    //이전에 클리어했나 확인
    public bool Isclear()
    {
        if (GameManager.Instance != null)
        {
            return GameManager.Instance.EasyClear;
        }
        return false;
    }
}