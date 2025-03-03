using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyDespawnByDisTance : DeSpawnByDistance
{
    protected override void DeSpawnObject()
    {
       BulletEnemySpawner.Instance.Despawn(transform.parent);
    }
}
