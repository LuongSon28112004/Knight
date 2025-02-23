using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : ModelMonoBehaviour
{
    [SerializeField] private float jumpSpeed = 6f;
    [SerializeField] private float moveSpeed = 3f;
    private float INCREASE_SPEED = 0.01f;
    private const float MAX_SPEED = 6f;
    [SerializeField] private bool doubleJump = false;
    [SerializeField] private Rigidbody2D m_rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerAnimationController playerAnimationController;

    public float JumpSpeed { get => jumpSpeed; }
    public float MoveSpeed { get => moveSpeed; }

    protected override void Awake()
    {
        m_rb = transform.parent.GetComponent<Rigidbody2D>();
        spriteRenderer = transform.parent.Find("Model").GetComponent<SpriteRenderer>();
        playerAnimationController = transform.parent.Find("Model").GetComponent<PlayerAnimationController>();
    }

    void FixedUpdate()
    {
        this.moving();
        this.IncreaseSpeedOverTime();
        this.jump();
        this.highJump();
        this.updateDoubleJump();
    }

    private void IncreaseSpeedOverTime()
    {
        if(InputManager.Instance.HorizontalInput != 0)
        {
            if(this.moveSpeed >= MAX_SPEED) return;
            this.moveSpeed += this.INCREASE_SPEED;
        }
        else{
            this.moveSpeed = 3;
        }
    }

    protected virtual void moving(){
        if(playerAnimationController.IsDead) return;
        float x = InputManager.Instance.HorizontalInput;
        m_rb.linearVelocity = new Vector2(x * moveSpeed, m_rb.linearVelocity.y);
        this.flipDirection(x);
    }

    protected void flipDirection(float value){
        if(value < 0){
            spriteRenderer.flipX = true;
        }
        else if(value > 0){
            spriteRenderer.flipX = false;
        }
    }

    protected virtual void jump()
    {
        jump(PlayerCollider.Instance.IsGround);
    }

    protected virtual void jump(bool isGround)
    {
        // Kiểm tra xem người chơi có đang đứng trên mặt đất
        if(InputManager.Instance.OnSpace && PlayerCollider.Instance.IsGround){
            Debug.Log("jump");
           m_rb.AddForce(Vector2.up * jumpSpeed ,ForceMode2D.Impulse );
           PlayerCollider.Instance.IsGround = false;
        }
    }

    protected virtual void highJump()
    {
        if(!doubleJump)
        {
            if(InputManager.Instance.OnDoubleSpace && !PlayerCollider.Instance.IsGround){
                Debug.Log("highJump");
                doubleJump = true;
                m_rb.AddForce(Vector2.up * jumpSpeed ,ForceMode2D.Impulse );
                InputManager.Instance.OnDoubleSpace = false;
            }
        }
    }

    protected void updateDoubleJump(){
        if(PlayerCollider.Instance.IsGround){
            doubleJump = false;
        }
    }

}
