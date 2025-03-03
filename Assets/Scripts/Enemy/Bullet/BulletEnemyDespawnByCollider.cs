using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyDespawnByCollider : DeSpawnByCollider
{

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         isDeSpawn = true;
      }
   }
   protected override void DeSpawnObject()
   {
      BulletEnemySpawner.Instance.Despawn(transform.parent);
   }
   
   

   
}
