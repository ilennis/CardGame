using UnityEngine;

public class StageManager : MonoBehaviour
{
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
        }

        Instance = this;
        DontDestroyOnLoad(this);

        Initialize();
    }

    private void Initialize()
    {

    }
}