using UnityEngine;

public class SoundFXToggle : BaseVolumeToggle
{
    private void Start()
    {
        toggle.isOn = PlayerPrefs.GetInt(StaticStringUI.AudioString.SFXString.SFX_VOLUME, 1) == 1;
    }

    public override void OnValueChanged(bool value)
    {
        if (IsAudioMixerLoaded())
        {
            float dB = value ? 0.0f : -80.0f;
            Debug.Log("Sound FX volume: " + dB);
            audioMixer.SetFloat(StaticStringUI.AudioString.SFXString.SFX_VOLUME, dB);

            // Save sound fx volume
            PlayerPrefs.SetInt(StaticStringUI.AudioString.SFXString.SFX_VOLUME, value ? 1 : 0);
        }
    }
    
}
