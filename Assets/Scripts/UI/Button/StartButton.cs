using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : BaseButton
{
   protected override void OnClick()
   {
       SceneManager.LoadScene(1);
   }
}
