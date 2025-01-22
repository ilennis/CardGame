using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject UnlockPanel;

    bool clear = false;

    public enum StageType
    {
        Easy,
        Hard
    }

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
        bool a = Isclear();
        Debug.Log(a);
    }

    private void Initialize()
    {

    }

    //해금 조건을 충족했나 체크
    public void ConditionCheck()
    {
        clear = Isclear();
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

    //이전에 클리어했나 확인
    bool Isclear()
    {
        bool key = PlayerPrefs.HasKey("easy"); //"easy"에 이지를 클리어했는지를 저장 
        return key;
    }
}