using System;
using System.Collections.Generic;
using DG.Tweening;
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
    private readonly HashSet<AudioClip> audioClips = new();

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
                int index = (int)type;
                if (audioSources[index].clip != null) return;
                audioSources[index].clip = clip;
                audioSources[index].DOFade(VOLUMES[index], 2.0f).From(0.0f);
                audioSources[index].Play();
                break;
            case AudioType.SoundFX:
                if (audioClips.Add(clip) == false) return;
                audioSources[(int)type].PlayOneShot(clip);
                DOVirtual.DelayedCall(0.1f, () => audioClips.Remove(clip));
                break;
            default:
                Debug.LogError($"Failed to Play({type})");
                break;
        }
    }

    public void StopMusic()
    {
        var music = audioSources[(int)AudioType.Music];
        var musicFX = audioSources[(int)AudioType.MusicFX];

        musicFX.clip = music.clip;
        musicFX.time = music.time;
        musicFX.volume = music.volume;
        musicFX.Play();
        musicFX.DOFade(0.0f, 1.0f).OnComplete(() =>
        {
            musicFX.Stop();
            musicFX.clip = null;
        });

        music.Stop();
        music.clip = null;
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