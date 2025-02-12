using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
   private void Start()
   {
      InitialAmountDamage();
   }

   void OnCollisionEnter2D(Collision2D other)
   {
      this.SendDamage(other.transform);
   }

   protected override void InitialAmountDamage()
   {
      this.amount = 1;
   }
}
