using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] EnemyAnimationController enemyAnimationController;
     private void Start()
    {
        this.CurrentHP = 5;
        this.MaxHP = this.CurrentHP;
        this.IsDead = false;
        enemyAnimationController = transform.parent.Find("Model").GetComponent<EnemyAnimationController>();
    }

    protected override void HitHandle()
    {
        enemyAnimationController.hitAnimation();
    }

    protected override void DeadHandle()
    {
        enemyAnimationController.deadAnimation();
    }

}
