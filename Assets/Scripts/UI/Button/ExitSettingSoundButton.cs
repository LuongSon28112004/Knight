using UnityEngine;

public class ExitSettingSoundButton : BaseButton
{
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject inforMain;
    protected override void OnClick()
    {
        settingPanel.SetActive(false);
        inforMain.SetActive(true);
    }
}

