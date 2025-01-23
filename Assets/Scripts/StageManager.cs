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
    public Canvas canvas;

    public bool clear = false;

    public StageType CurrentStage { get; private set; } = StageType.Easy;
    public static StageManager Instance { get; private set; }

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
        AudioManager.Instance.StopMusic();

        DOVirtual.DelayedCall(1.0f, () =>
        {
            //�ϵ����϶�
            if (stage == StageType.Hard)
            {
                if (clear == true)
                {
                    CurrentStage = stage;
                    SceneManager.LoadScene(1);
                }
            }
            //��������� ��
            else
            {
                CurrentStage = stage;
                SceneManager.LoadScene(1);
            }
        });
    }

    //������ Ŭ�����߳� Ȯ��
    public bool Isclear()
    {
        if (GameManager.Instance != null)
        {
            return GameManager.Instance.EasyClear;
        }
        return false;
    }
}