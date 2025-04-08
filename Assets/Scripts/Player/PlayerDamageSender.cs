using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamageSender : DamageSender
{
    [SerializeField]
    PlayerAnimationController playerAnimationController;

    [SerializeField]
    ParticleSystem chestParticleSystem;

    [SerializeField]
    Vector3 left;

    [SerializeField]
    Vector3 right;

    int countAttack = 0;

    private void Start()
    {
        playerAnimationController = transform
            .parent.Find("Model")
            .GetComponent<PlayerAnimationController>();
        GetComponent<BoxCollider2D>().enabled = false;
        chestParticleSystem = GameObject.FindGameObjectWithTag("ParticleChest").GetComponent<ParticleSystem>();
        this.InitialAmountDamage();
        this.initValue();
    }

    void Update()
    {
        this.Attack();
        this.changeDirection();
    }

    private void initValue()
    {
        this.left = new Vector3(-4f, transform.localPosition.y, transform.localPosition.z);
        this.right = new Vector3(2f, transform.localPosition.y, transform.localPosition.z);
    }

    private void changeDirection()
    {
        if (transform.parent.Find("Model").GetComponent<SpriteRenderer>().flipX == true)
        {
            transform.localPosition = left;
        }
        else
            transform.localPosition = right;
    }

    private void Attack()
    {
        if (playerAnimationController.Attacked && countAttack == 0)
        {
            Debug.Log("attacked");
            //this.updatePosition();
            this.startAttack();
            Invoke(nameof(EndAttack), 0.7f);
            countAttack = 1;
        }
    }
    
    /// <summary>
    /// Send damage to enemy
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerAnimationController.Attacked && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("player send dame");
            this.SendDamage(other.transform);
        }

        //tao particle va destroy object chest
        if (playerAnimationController.Attacked && other.gameObject.CompareTag("Chest"))
        {
            chestParticleSystem.transform.position = other.transform.position;
            chestParticleSystem.transform.rotation = other.transform.rotation;
            chestParticleSystem.Play();
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// Send damage to enemy
    /// </summary>
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
