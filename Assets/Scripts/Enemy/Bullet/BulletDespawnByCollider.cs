using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnByCollider : DeSpawnByCollider
{
     protected override void DeSpawnObject()
    {
       BulletEnemySpawner.Instance.Despawn(transform.parent);
    }
}
