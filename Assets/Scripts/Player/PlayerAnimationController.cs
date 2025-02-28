using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerAnimationController : ModelMonoBehaviour
{
    [SerializeField]
    private Animator anim;
    private bool isJumping = false; // Biến kiểm tra trạng thái nhảy
    private float skill = 0;
    PlayerDamagerReceiver playerDamagerReceiver;
    PlayerMovement playerMovement;

    [SerializeField]
    private bool attacked = false;
    public bool Attacked
    {
        get => attacked;
    }

    [SerializeField]
    private bool isDead = false;
    public bool IsDead
    {
        get => isDead;
    }

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        playerDamagerReceiver = transform
            .parent.Find("PlayerCollider")
            .GetComponent<PlayerDamagerReceiver>();
        playerMovement = transform.parent.Find("PlayerMovement").GetComponent<PlayerMovement>();
        if (anim == null)
            Debug.LogWarning("Animator of Player is null");
    }

    private void Start()
    {
        this.AddAnimationEvent();
    }

    private void Update()
    {
        this.SetAnimation();
    }

    private void SetAnimation()
    {
        this.walking(); // Cập nhật trạng thái đi bộ
        this.jumping(); // Cập nhật trạng thái nhảy
        this.attacking();
        this.highJumping(); // Cập nhật tráng thái nhảy cao
    }

    public void AddAnimationEvent()
    {
        if (anim == null || anim.runtimeAnimatorController == null)
            return; // Kiểm tra anim và runtimeAnimatorController có null không

        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {
            AnimationEvent aniEventLast = new AnimationEvent
            {
                time = 0.01f,
                functionName =
                    (clip.name == "Player_Hurt") ? nameof(hitFinished)
                    : (clip.name == "Player_Attack") ? nameof(CheckAttacked)
                    : (clip.name == "PlayerAttack1") ? nameof(CheckAttacked)
                    : (clip.name == "PlayerAttack2") ? nameof(CheckAttacked)
                    : null,
            };


            // Thêm sự kiện vào clip nếu có tên hàm hợp lệ
            if (!string.IsNullOrEmpty(aniEventLast.functionName))
            {
                try
                {
                    clip.AddEvent(aniEventLast);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to add event to clip {clip.name}: {ex.Message}");
                }
            }

        }
    }

    private void walking()
    {
        if (!isJumping) // Kiểm tra nếu không ở trạng thái nhảy
        {
            if (InputManager.Instance.HorizontalInput != 0)
            {
                anim.SetBool("IsMoving", true);
                anim.SetFloat("SpeedMoving", playerMovement.MoveSpeed);
            }
            else
            {
                anim.SetBool("IsMoving", false);
                anim.SetFloat("SpeedMoving", 0);
            }
        }
    }

    private void jumping()
    {
        if (InputManager.Instance.OnSpace && PlayerCollider.Instance.IsGround)
        {
            isJumping = true; // Đánh dấu là đang nhảy
            anim.SetFloat("SpeedJumping", playerMovement.JumpSpeed);
            anim.SetBool("IsMoving", true);
        }
        else if (PlayerCollider.Instance.IsGround)
        {
            isJumping = false; // Khi nhân vật chạm đất, không còn ở trạng thái nhảy
            anim.SetFloat("SpeedJumping", 0);
        }
    }

    private void attacking()
    {
        if (InputManager.Instance.OnKeyX && !attacked)
        {
            Debug.Log("ok x");
            anim.SetTrigger("Attack");
            anim.SetFloat("Skill", skill);
            skill++;
            if (skill == 3)
                skill = 0;
        }
    }

    public void CheckAttacked()
    {
        this.attacked = true;
    }

    public void resetAttacked()
    {
        this.attacked = false;
        Debug.Log("attack reset");
        //StartCoroutine(ResetAttackedDelay());
    }

    private IEnumerator ResetAttackedDelay()
    {
        yield return new WaitForSeconds(0.5f); // Đợi 0.1s trước khi reset
        this.attacked = false;
    }

    
    public void hitFinished()
    {
        playerDamagerReceiver.ResetIsBeingHit();
    }

    public async void hurting()
    {
        Time.timeScale = 0;
        anim.SetTrigger("Hit");
        anim.SetFloat("Hitted", 0);

        await Task.Delay(500); // Đợi 2 giây (vẫn hoạt động khi Time.timeScale = 0)

        Time.timeScale = 1;
        Debug.Log("Hurting animation kết thúc, tiếp tục xử lý!");
    }


    public void deathing()
    {
        anim.SetTrigger("Hit");
        anim.SetFloat("Hitted", 1);
        anim.SetBool("IsDead", true);
        isDead = true;
    }

    private void highJumping()
    {
        //for update
    }

}
