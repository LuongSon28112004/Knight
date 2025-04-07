using UnityEngine;

public class MusicToogle : BaseVolumeToggle
{
    private void Start()
    {

        toggle.isOn = PlayerPrefs.GetInt(StaticStringUI.AudioString.MusicString.TOGGLE_MUSIC, 1) == 1;
    }

    public override void OnValueChanged(bool value)
    {
        if (IsAudioMixerLoaded())
        {
            float dB = value ? StaticConst.MAX_DB : StaticConst.MIN_DB;
            audioMixer.SetFloat(StaticStringUI.AudioString.MusicString.MUSIC_VOLUME, dB);

            // Save music volume
            PlayerPrefs.SetInt(StaticStringUI.AudioString.MusicString.TOGGLE_MUSIC, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
