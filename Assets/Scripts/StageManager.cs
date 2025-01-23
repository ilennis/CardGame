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
        if (clear != true)
        {
            clear = Isclear();
        } 
        //하드모드를 선택할때 해금이 불가능이라면
        if (clear == false)
        {
            UnlockPanel.SetActive(true);
        }
        else
        {

            //하드모드 게임 씬 로드
        }
    }

    public void SelectStage(StageType stage)
    {
        CurrentStage = stage;
        SceneManager.LoadScene(1);
    }

    //이전에 클리어했나 확인
    bool Isclear()
    {
        if (GameManager.Instance.Success >=6)
        {
            return true;
        }
        return false;
    }
}