using UnityEngine;

public class CheatManager : MonoBehaviour
{
    #region References
    [Header("References")]
    [SerializeField]
    private Board board;
    #endregion

    private void Awake() => Initialize();

    private void Initialize()
    {

    }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (var item in board.CardList)
            {
                Debug.Log(item.name);
            }
        }
    }
}