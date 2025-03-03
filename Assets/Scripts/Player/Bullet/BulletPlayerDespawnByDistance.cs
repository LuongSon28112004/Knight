using UnityEngine;

public class BulletPlayerDespawnByDistance : DeSpawnByDistance
{
    protected override void DeSpawnObject()
    {
        BulletPlayerSpawner.Instance.Despawn(transform.parent);
    }
}
