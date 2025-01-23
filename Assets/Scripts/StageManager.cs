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

    //�ر� ������ �����߳� üũ
    public void ConditionCheck()
    {
        if (clear != true)
        {
            clear = Isclear();
        } 
        //�ϵ��带 �����Ҷ� �ر��� �Ұ����̶��
        if (clear == false)
        {
            UnlockPanel.SetActive(true);
        }
        else
        {

            //�ϵ��� ���� �� �ε�
        }
    }

    public void SelectStage(StageType stage)
    {
        CurrentStage = stage;
        SceneManager.LoadScene(1);
    }

    //������ Ŭ�����߳� Ȯ��
    bool Isclear()
    {
        if (GameManager.Instance.Success >=6)
        {
            return true;
        }
        return false;
    }
}