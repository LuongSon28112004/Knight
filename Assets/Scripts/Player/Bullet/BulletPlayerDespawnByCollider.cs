using UnityEngine;

public class BulletPlayerDespawnByCollider : DeSpawnByCollider
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDeSpawn = true;
        }
    }
   protected override void DeSpawnObject()
   {
      BulletPlayerSpawner.Instance.Despawn(transform.parent);
   }
}
