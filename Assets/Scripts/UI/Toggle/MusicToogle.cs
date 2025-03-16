using UnityEngine;

public class MusicToogle : BaseVolumeToggle
{
    private void Start()
    {
        toggle.isOn = PlayerPrefs.GetInt(StaticStringUI.AudioString.MusicString.MUSIC_VOLUME, 1) == 1;
    }

    public override void OnValueChanged(bool value)
    {
        if (IsAudioMixerLoaded())
        {
            float dB = value ? 10.0f : -80.0f;
            Debug.Log("Music volume: " + dB);
            audioMixer.SetFloat(StaticStringUI.AudioString.MusicString.MUSIC_VOLUME, dB);

            // Save music volume
            PlayerPrefs.SetInt(StaticStringUI.AudioString.MusicString.MUSIC_VOLUME, value ? 1 : 0);
        }
    }
}
