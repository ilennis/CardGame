using UnityEngine;

public abstract class Scene_Base : MonoBehaviour
{
    private void Awake()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        if (AudioManager.Instance != null)
        {
            return;
        }

        new GameObject(nameof(AudioManager), typeof(AudioManager));
    }
}