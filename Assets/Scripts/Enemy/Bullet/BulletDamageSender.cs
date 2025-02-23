using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    private void Start()
    {
        InitialAmountDamage();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      //   Debug.Log("" + other.gameObject.name);
        this.SendDamage(other.transform);
    }

    protected override void InitialAmountDamage()
    {
        this.amount = 1;
    }
}
