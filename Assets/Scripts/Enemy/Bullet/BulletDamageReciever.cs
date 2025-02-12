using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageReciever : DamageReceiver
{
     private void Start()
    {
        this.CurrentHP = 5;
        this.MaxHP = this.CurrentHP;
        this.IsDead = false;
    }

    protected override void HitHandle()
    {
        
    }

    protected override void DeadHandle()
    {
        
    }
}
