using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyDamageReciever : DamageReceiver
{
     private void Start()
    {
        this.currentHP = 5;
        this.maxHP = this.CurrentHP;
        this.IsDead = false;
    }

    protected override void HitHandle()
    {
        
    }

    protected override void DeadHandle()
    {
        
    }
}
