using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SoundBackGroundMusicManager : SoundManager
{
    public static SoundBackGroundMusicManager Instance { get; private set; }

    private new void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        base.Awake();
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    protected override void LoadAudioClips()
    {
        clips = new();

        AsyncOperationHandle<IList<AudioClip>> handle = Addressables.LoadAssetsAsync<AudioClip>(new List<string>() { "MusicBackGround" },
        addressables =>
        {
            if (addressables != null)
            {
                clips.Add(addressables);
            }
        },
        Addressables.MergeMode.Union,
        false);

        handle.Completed += Load_Completed;
    }

    private void Load_Completed(AsyncOperationHandle<IList<AudioClip>> handle)
    {
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Music background could not loaded!");
            return;
        }

       PlaySound("BackGroundMusic");
    }

    protected override void InitialVolume()
    {
        // float value = PlayerPrefs.GetFloat(AudioString.MusicString.MUSIC_VOLUME);
        //audioMixer.SetFloat(AudioString.MusicString.MUSIC_VOLUME, Mathf.Log10(value) * 20);
    }
}
