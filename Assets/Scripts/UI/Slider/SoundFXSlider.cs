using UnityEngine;

public class SoundFXSlider : BaseVolumeSlider
{
    private const float minDB = -80.0f;
    private const float maxDB = 10.0f;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(StaticStringUI.AudioString.SFXString.SFX_VOLUME,1.0f);

        // Nếu audioMixer đã được load thì khởi tạo volume ngay lập tức
        if (IsAudioMixerLoaded())
        {
            InitialVolume();
        }
    }

    public override void OnValueChanged(float value)
    {
        if (IsAudioMixerLoaded())
        {
            float dB = Mathf.Lerp(minDB, maxDB, value);
            Debug.Log("Music volume: " + dB);
            audioMixer.SetFloat(StaticStringUI.AudioString.SFXString.SFX_VOLUME, dB);

            // Save music volume
            PlayerPrefs.SetFloat(StaticStringUI.AudioString.SFXString.SFX_VOLUME, value);
        }
    }

    protected override void InitialVolume()
    {
        if (IsAudioMixerLoaded())
        {
            float dB = Mathf.Lerp(minDB, maxDB, slider.value);
            audioMixer.SetFloat(StaticStringUI.AudioString.SFXString.SFX_VOLUME, dB);
        }
    }
}
