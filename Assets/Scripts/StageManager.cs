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

    //�ر� ������ �����߳� üũ
    public void ConditionCheck()
    {
        clear = Isclear();
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

    //������ Ŭ�����߳� Ȯ��
    bool Isclear()
    {
        bool key = PlayerPrefs.HasKey("easy"); //"easy"�� ������ Ŭ�����ߴ����� ���� 
        return key;
    }
}