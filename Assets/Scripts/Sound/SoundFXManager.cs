using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class SoundFXManager : SoundManager
{
    public static SoundFXManager Instance { get; private set; }

    private new void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        base.Awake();

        //DontDestroyOnLoad(transform.parent.gameObject);
    }

    protected override void LoadAudioClips()
    {
        clips = new();

        AsyncOperationHandle<IList<AudioClip>> handle = Addressables.LoadAssetsAsync<AudioClip>(
            new List<string>() { "SoundFX" },
            addressables =>
            {
                if (addressables != null)
                {
                    clips.Add(addressables);
                }
            },
            Addressables.MergeMode.Union,
            false
        );

        handle.Completed += Load_Completed;
    }

    private void Load_Completed(AsyncOperationHandle<IList<AudioClip>> handle)
    {
        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogWarning("Some sound effect assets could not loaded!");
            return;
        }
    }

    protected override void InitialVolume()
    {
        // float value = PlayerPrefs.GetFloat(AudioString.SoundString.SOUND_VOLUME);
        //audioMixer.SetFloat(AudioString.SoundString.SOUND_VOLUME, Mathf.Log10(value) * 20);
    }
}
