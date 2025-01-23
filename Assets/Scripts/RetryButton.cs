using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(4);
        GameManager.Instance.IsEnded = false;
        GameManager.Instance.Time = GameManager.TIME;
    }
}
