using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagerReceiver : DamageReceiver
{
    [SerializeField] PlayerAnimationController playerAnimationController;
    private void Start()
    {
        playerAnimationController = transform.parent.Find("Model").GetComponent<PlayerAnimationController>();
        this.currentHP = 5;
        this.maxHP = currentHP;
        this.IsDead = false;
    }

    protected override void HitHandle()
    {
        playerAnimationController.Hurting();
    }

    protected override void DeadHandle()
    {
        playerAnimationController.deathing();
    }
}
