using UnityEngine;
using UnityEngine.SceneManagement;

public enum StageType
{
    Easy,
    Hard
}

public class StageManager : MonoBehaviour
{
    public GameObject UnlockPanel;

    bool clear = false;

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

        Initialize();
    }

    public void Start()
    {

    }

    private void Initialize()
    {

    }

    //해금 조건을 충족했나 체크
    public void ConditionCheck()
    {
        //깼는지에 대한 기록 갱신
        if (clear != true)
        {
            clear = Isclear();
        }

        //하드모드를 선택할때 해금이 불가능이라면
        if (clear == false)
        {
            UnlockPanel.SetActive(true);
            UnlockPanel.GetComponent<AudioSource>().Play();
        }
    }

    public void SelectStage(StageType stage)
    {
        //하드모드일 때
        if (stage == StageType.Hard)
        {
            ConditionCheck();
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
    }

    //이전에 클리어했나 확인
    bool Isclear()
    {
        int sucess = 0;
        if (GameManager.Instance != null)
        {
            sucess = GameManager.Instance.Success;
        }
        
        if (sucess >= 6)
        {
            return true;
        }
        return false;
    }
}