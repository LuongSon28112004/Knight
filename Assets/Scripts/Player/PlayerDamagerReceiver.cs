using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagerReceiver : DamageReceiver
{
    [SerializeField] PlayerAnimationController playerAnimationController;
    private void Start()
    {
        playerAnimationController = transform.parent.Find("Model").GetComponent<PlayerAnimationController>();
        this.CurrentHP = 7;
        this.MaxHP = CurrentHP;
        this.IsDead = false;
    }

    protected override void HitHandle()
    {
        playerAnimationController.hurting();
    }

    protected override void DeadHandle()
    {
        playerAnimationController.deathing();
    }
}
