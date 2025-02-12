using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [SerializeField] PlayerAnimationController playerAnimationController;
    private void Start()
    {
        playerAnimationController = transform.parent.Find("Model").GetComponent<PlayerAnimationController>();
        InitialAmountDamage();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("" + other.gameObject.name);
        if(playerAnimationController.Attacked)
        this.SendDamage(other.transform);
    }

    protected override void InitialAmountDamage()
    {
       this.amount = 1;
    }
}
