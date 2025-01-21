using System;
using UnityEngine;

public enum AudioType
{
    Music,
    MusicFX,
    SoundFX,
    Count
}

public class AudioManager : MonoBehaviour
{
    private readonly float[] VOLUMES =
    {
        0.1f,   // Music
        0.1f,   // MusicFX
        0.2f    // SoundFX
    };

    public static AudioManager Instance { get; private set; }

    private readonly AudioSource[] audioSources = new AudioSource[(int)AudioType.Count];

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
        string[] names = Enum.GetNames(typeof(AudioType));
        for (int i = 0; i < audioSources.Length; i++)
        {
            var childObject = new GameObject(names[i]).transform;
            childObject.SetParent(transform);

            var audioSource = childObject.gameObject.AddComponent<AudioSource>();
            audioSource.loop = (AudioType)i != AudioType.SoundFX;
            audioSource.volume = VOLUMES[i];
            audioSources[i] = audioSource;
        }
    }

    public void Play(string key)
    {
        var clip = Resources.Load<AudioClip>($"Audio/{key}");
        if (clip == null)
        {
            Debug.LogError($"Failed to Load<AudioClip>(Audio/{key})");
            return;
        }

        var type = GetType(key);
        switch (type)
        {
            case AudioType.Music:
                audioSources[(int)type].clip = clip;
                audioSources[(int)type].Play();
                break;
            case AudioType.SoundFX:
                audioSources[(int)type].PlayOneShot(clip);
                break;
            default:
                Debug.LogError($"Failed to Play({type})");
                break;
        }
    }

    private void Play_MusicFX()
    {
        // TODO: 크로스 페이드 구현
    }

    private AudioType GetType(string key)
    {
        var type = key[..key.IndexOf('_')];
        if (Enum.TryParse(typeof(AudioType), type, out var audioType))
        {
            return (AudioType)audioType;
        }

        return AudioType.Count;
    }
}