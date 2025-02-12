using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimationController : ModelMonoBehaviour
{
    [SerializeField] private Animator anim;
    //private int statusEnemy;
    //animation attack
    [SerializeField] private EnemySeePlayer enemySeePlayer;
    [SerializeField] private EnemyDamageReceiver enemyDamageReceiver;
    [SerializeField] private bool isAttackAnimationFinished;
    //EnemySeePlayer
    public bool IsAttackAnimationFinished { get => isAttackAnimationFinished;}
    [SerializeField] private bool isDead = false;
    public bool IsDead { get => isDead; set => isDead = value; }

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
        enemySeePlayer = transform.parent.Find("SeePlayer").GetComponent<EnemySeePlayer>();
        enemyDamageReceiver = transform.parent.Find("EnemyCollider").GetComponent<EnemyDamageReceiver>();
    }

    private void Start() {
        this.AddAnimationEvent();
    }

    void Update()
    {
        this.AttackAnimation();
    }

    public void AddAnimationEvent()
    {
        if (anim == null) return; // Kiểm tra anim có null không

        foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips)
        {

            // Tạo sự kiện cho thời gian cuối clip
            AnimationEvent aniEventLast = new AnimationEvent
            {
                time = clip.length - 0.01f,
                functionName = (clip.name == "EnemyAttack") ? nameof(checkAttackAnimationFinished) : 
                                (clip.name == "EnemyHit") ? nameof(hitFinished) : ""
            };

            // Tạo sự kiện cho thời gian đầu clip
            AnimationEvent aniEventFirst = new AnimationEvent
            {
                time = 0,
                functionName = (clip.name == "EnemyAttack") ? nameof(checkAttackAnimationUnFinished) : 
                            (clip.name == "EnemyWalk") ? nameof(checkAttackAnimationUnFinished) : ""
            };

            // Thêm sự kiện vào clip nếu có tên hàm hợp lệ
            if (!string.IsNullOrEmpty(aniEventFirst.functionName)) clip.AddEvent(aniEventFirst);
            if (!string.IsNullOrEmpty(aniEventLast.functionName)) clip.AddEvent(aniEventLast);
        }
    }




    private void AttackAnimation()
    {
        if(enemySeePlayer.SeePlayer)
        {
            anim.SetBool("IsAttacking",true);
            anim.SetBool("IsMoving",false);
        }
        else{
            anim.SetBool("IsMoving",true);
            anim.SetBool("IsAttacking",false);
        }
    }

    public void hitAnimation()
    {
        anim.SetTrigger("Hit");
        anim.SetFloat("Hitted",0);
    }

    public void hitFinished()
    {
        enemyDamageReceiver.ResetIsBeingHit();
    }

    public void deadAnimation()
    {
        anim.SetTrigger("Hit");
        anim.SetFloat("Hitted",1);
        anim.SetBool("IsDead",true);
        this.IsDead = true;
    }

    // private void updateStatus()
    // {
    //     anim.SetInteger("Status", statusEnemy);
    // }
    
    public void checkAttackAnimationFinished()
    {
        isAttackAnimationFinished = true;
    }

    public void checkAttackAnimationUnFinished()
    {
        isAttackAnimationFinished = false;
    }
    
}
