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
        GetComponent<BoxCollider2D>().enabled = false;
    }

    void Update()
    {
        this.Attack();
    }

    private void Attack()
    {
        if(playerAnimationController.Attacked)
        {
            this.startAttack();
            Invoke(nameof(EndAttack), 0.4f); 
            playerAnimationController.resetAttacked();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(playerAnimationController.Attacked)
        {
            Debug.Log("player send dame");
            this.SendDamage(other.transform);
        }
    }

    private void startAttack()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void EndAttack()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }


    protected override void InitialAmountDamage()
    {
       this.amount = 1;
    }
}

