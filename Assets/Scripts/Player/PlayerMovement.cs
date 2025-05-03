using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ModelMonoBehaviour
{
    [SerializeField]
    private float jumpSpeed = 6f;

    [SerializeField]
    private float moveSpeed = 3f;
    private int jumpCount = 0;
    private bool hasReleasedJump = false;
    private float INCREASE_SPEED = 0.01f;
    private const float MAX_SPEED = 5f;

    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    private Rigidbody2D m_rb;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private PlayerAnimationController playerAnimationController;

    public float JumpSpeed
    {
        get => jumpSpeed;
    }
    public float MoveSpeed
    {
        get => moveSpeed;
    }

    protected override void Awake()
    {
        m_rb = transform.parent.GetComponent<Rigidbody2D>();
        spriteRenderer = transform.parent.Find("Model").GetComponent<SpriteRenderer>();
        playerAnimationController = transform
            .parent.Find("Model")
            .GetComponent<PlayerAnimationController>();
    }

    void FixedUpdate()
    {
        this.moving();
        this.moveJoystick();
        this.IncreaseSpeedOverTime();
        this.jump();
        this.highJump();
        this.resetJumpCount();
    }

    /// <summary>
    /// Tăng tốc độ di chuyển theo thời gian
    /// </summary>
    private void IncreaseSpeedOverTime()
    {
        if (InputManager.Instance.HorizontalInput != 0)
        {
            if (this.moveSpeed >= MAX_SPEED)
                return;
            this.moveSpeed += this.INCREASE_SPEED;
        }
        else
        {
            this.moveSpeed = 3;
        }
    }

    /// <summary>
    /// Di chuyển nhân vật
    /// </summary>
    /// <param name="isGround">Kiểm tra xem nhân vật có đang đứng trên mặt đất hay không</param>
    protected virtual void moving()
    {
        if (playerAnimationController.IsDead)
            return;
        float x = InputManager.Instance.HorizontalInput;
        m_rb.linearVelocity = new Vector2(x * moveSpeed, m_rb.linearVelocity.y);
        this.flipDirection(x);
    }

    protected void moveJoystick()
    {
        if (playerAnimationController.IsDead)
            return;
        float x = joystick.Horizontal;
        if (Mathf.Abs(x) < 0.1f)
            return;
        m_rb.linearVelocity = new Vector2(x * moveSpeed, m_rb.linearVelocity.y);
        this.flipDirection(x);
    }

    /// <summary>
    /// Lật hướng nhân vật
    /// </summary>
    /// <param name="value">Giá trị đầu vào</param>
    protected void flipDirection(float value)
    {
        if (value < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (value > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    /// <summary>
    /// Nhảy nhân vật
    /// </summary>
    /// <param name="isGround">Kiểm tra xem nhân vật có đang đứng trên mặt đất hay không</param>
    /// <param name="jumpCount">Số lần nhảy</param>
    protected virtual void jump()
    {
        jump(PlayerCollider.Instance.IsGround);
    }

    /// <summary>
    /// Nhảy nhân vật
    /// </summary>
    /// <param name="isGround">Kiểm tra xem nhân vật có đang đứng trên mặt đất hay không</param>
    /// <param name="jumpCount">Số lần nhảy</param>
    protected virtual void jump(bool isGround)
    {
        // Kiểm tra xem người chơi có đang đứng trên mặt đất
        if (InputManager.Instance.OnSpace && isGround && jumpCount == 0)
        {
            Debug.Log("jump");
            jumpCount = 1;
            hasReleasedJump = false;
            m_rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            PlayerCollider.Instance.IsGround = false;
        }
    }

    /// <summary>
    /// Nhảy cao hơn
    /// </summary>
    /// <param name="isGround">Kiểm tra xem nhân vật có đang đứng trên mặt đất hay không</param>
    /// <param name="jumpCount">Số lần nhảy</param>
    protected virtual void highJump()
    {
        if (jumpCount == 1 && !PlayerCollider.Instance.IsGround)
        {
            if (!InputManager.Instance.OnSpace)
            {
                hasReleasedJump = true;
            }
            if (InputManager.Instance.OnSpace && hasReleasedJump)
            {
                Debug.Log("highJump");
                jumpCount = 2;
                hasReleasedJump = false; //tranh nhay 3 lan
                m_rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }

    /// <summary>
    /// Đặt lại số lần nhảy
    /// </summary>
    /// <param name="isGround">Kiểm tra xem nhân vật có đang đứng trên mặt đất hay không</param>
    /// <param name="jumpCount">Số lần nhảy</param>
    /// <param name="hasReleasedJump">Kiểm tra xem người chơi đã nhả phím nhảy hay chưa</param>
    private void resetJumpCount()
    {
        if (PlayerCollider.Instance.IsGround)
        {
            jumpCount = 0;
            hasReleasedJump = false;
        }
    }
}
