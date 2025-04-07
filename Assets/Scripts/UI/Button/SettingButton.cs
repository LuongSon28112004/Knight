using UnityEngine;

public class SettingButton : BaseButton
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject inforMain;
    protected override void OnClick()
    {
        settingPanel.SetActive(true);
        inforMain.SetActive(false);
    }
}
