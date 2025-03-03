using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByCollider : Despawn
{
    [SerializeField] protected bool isDeSpawn = false;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override bool CanDespawn()
    {
        return isDeSpawn;
    }

    private void OnEnable() {
        isDeSpawn = false;
    }
}