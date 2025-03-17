using UnityEngine;

public class ExitButton : BaseButton
{
    protected override void OnClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Dừng Play Mode trong Editor
        #else
        Application.Quit(); // Thoát ứng dụng khi đã build
        #endif
    }
}
