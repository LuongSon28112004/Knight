using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
}
