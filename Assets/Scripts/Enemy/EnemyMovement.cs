using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : ModelMonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed = 2f; // Tốc độ di chuyển của enemy

    //so lan lat
    [SerializeField]
    private int countFlip = 1;

    //hướng của enemy
    [SerializeField]
    private bool isleft;

    [SerializeField]
    private bool isright;

    //eney collider
    [SerializeField]
    private EnemyCollider enemyCollider;

    //enemyAnimation
    [SerializeField]
    private EnemyAnimationController enemyAnimationController;

    //enemySeePlayer
    [SerializeField]
    private EnemySeePlayer enemySeePlayer;

    protected override void Awake()
    {
        spriteRenderer = transform.parent.Find("Model").GetComponent<SpriteRenderer>();
        enemyCollider = transform.parent.Find("EnemyCollider").GetComponent<EnemyCollider>();
        enemySeePlayer = transform.parent.Find("SeePlayer").GetComponent<EnemySeePlayer>();
        enemyAnimationController = transform
            .parent.Find("Model")
            .GetComponent<EnemyAnimationController>();
        this.isright = true;
        this.isleft = false;
    }

    void Update()
    {
        //move
        this.Move();
        //change direction
        this.changeDirection();
        this.resetCountFlip();
        this.resetSpeed();
        //move to player to shooting
        this.flipOnShoot();
    }

    private void Move()
    {
        if (enemyAnimationController.IsDead)
            return;
        if (enemySeePlayer.SeePlayer)
            return;
        if (enemySeePlayer.SeePlayer && !enemyAnimationController.IsAttackAnimationFinished)
            return;
        transform.parent.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void flipOnShoot()
    {
        if (enemySeePlayer.DistanceEnemyToPlayer.x < 0 && enemySeePlayer.SeePlayer)
        {
            spriteRenderer.flipX = false;
            isright = true;
            isleft = false;
        }
        else if (enemySeePlayer.DistanceEnemyToPlayer.x > 0 && enemySeePlayer.SeePlayer)
        {
            spriteRenderer.flipX = true; // can lat
            isleft = true;
            isright = false;
        }
    }

    private void changeDirection()
    {
        if (enemyCollider.IsCheck && countFlip == 1 && !enemySeePlayer.SeePlayer)
        {
            this.Flip();
            countFlip = 0;
        }
    }

    private void resetSpeed()
    {
        if (isleft)
        {
            this.speed = -2f;
        }
        else if (isright)
        {
            this.speed = 2f;
        }
    }

    private void resetCountFlip()
    {
        if (!enemyCollider.IsCheck)
        {
            countFlip = 1;
        }
    }

    private void Flip()
    {
        isright = !isright;
        isleft = !isleft;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
