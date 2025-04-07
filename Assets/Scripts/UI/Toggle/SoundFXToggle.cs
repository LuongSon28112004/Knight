using UnityEngine;

public class SoundFXToggle : BaseVolumeToggle
{
    private void Start()
    {
        toggle.isOn = PlayerPrefs.GetInt(StaticStringUI.AudioString.SFXString.TOGGLE_SFX, 1) == 1;
    }

    public override void OnValueChanged(bool value)
    {
        if (IsAudioMixerLoaded())
        {
            float dB = value ? StaticConst.MAX_DB : StaticConst.MIN_DB;
            audioMixer.SetFloat(StaticStringUI.AudioString.SFXString.SFX_VOLUME, dB);

            // Save sound fx volume
            PlayerPrefs.SetInt(StaticStringUI.AudioString.SFXString.TOGGLE_SFX, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    
}
