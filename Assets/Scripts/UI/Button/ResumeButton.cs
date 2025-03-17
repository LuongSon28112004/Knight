using UnityEngine;

public class ResumeButton : BaseButton
{
    [SerializeField] GameObject PauseGameobject;
    protected override void OnClick()
    {
        Time.timeScale = 1;
        PauseGameobject.SetActive(false);
    }
}