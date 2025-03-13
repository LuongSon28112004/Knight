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
        this.currentHP = 2;
        this.maxHP = this.currentHP;
        this.IsDead = false;
        enemyAnimationController = transform.parent.Find("Model").GetComponent<EnemyAnimationController>();
        enemyKnockBack = transform.parent.GetComponent<EnemyKnockBack>();
        Player = GameObject.Find("Player");
    }

    protected override void HitHandle()
    {
        Debug.Log("enemy hit");
        enemyAnimationController.hitAnimation();
        enemyKnockBack.ApplyKnockback(Player.transform);
    }

    protected override void DeadHandle()
    {
        enemyAnimationController.deadAnimation();
    }

}
