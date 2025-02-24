using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
