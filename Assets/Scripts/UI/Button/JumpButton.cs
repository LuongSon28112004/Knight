using System;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private Button jumpButton;
    [SerializeField] private PlayerMovement playerMovement;

    public event Action OnJumpButton;
    public event Action OnHighJumpButton;

    private bool isClickedJumpButton = false;
    public bool IsClickedJumpButton
    {
        get => isClickedJumpButton;
        set => isClickedJumpButton = value;
    }

    void Start()
    {
        // Lấy Button component nếu chưa gán sẵn
        if (jumpButton == null)
            jumpButton = GetComponent<Button>();

        // Gán sự kiện chỉ một lần duy nhất
        jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    private void OnJumpButtonClicked()
    {
        isClickedJumpButton = true; // Đánh dấu nút đã được nhấn
        if (playerMovement.JumpCount == 0)
        {
            OnJumpButton?.Invoke();
        }
        else if (playerMovement.JumpCount == 1)
        {
            OnHighJumpButton?.Invoke();
        }
    }
}
