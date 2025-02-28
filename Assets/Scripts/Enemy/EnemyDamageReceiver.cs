using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] EnemyAnimationController enemyAnimationController;
    [SerializeField] EnemyKnockBack enemyKnockBack;
    [SerializeField] GameObject Player;
     private void Start()
    {
        this.CurrentHP = 5;
        this.MaxHP = this.CurrentHP;
        this.IsDead = false;
        enemyAnimationController = transform.parent.Find("Model").GetComponent<EnemyAnimationController>();
        enemyKnockBack = transform.parent.GetComponent<EnemyKnockBack>();
        Player = GameObject.Find("Player");
    }

    protected override void HitHandle()
    {
        enemyAnimationController.hitAnimation();
        enemyKnockBack.ApplyKnockback(Player.transform);
    }

    protected override void DeadHandle()
    {
        enemyAnimationController.deadAnimation();
    }

}
