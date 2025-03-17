using UnityEngine;

public class PauseButton : BaseButton
{
    [SerializeField]
    GameObject pauseGameobject;

    protected override void OnClick()
    {
        Time.timeScale = 0;
        pauseGameobject.SetActive(true);
    }
}
