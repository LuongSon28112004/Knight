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

    int countAttack = 0;

    void Update()
    {
        this.Attack();
    }

    private void Attack()
    {
        if(playerAnimationController.Attacked && countAttack == 0)
        {
            this.startAttack();
            Invoke(nameof(EndAttack), 0.7f); 
            countAttack = 1;
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
        playerAnimationController.resetAttacked();
        countAttack = 0;
    }


    protected override void InitialAmountDamage()
    {
       this.amount = 1;
    }
}

