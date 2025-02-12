using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByCollider : Despawn
{
    [SerializeField] private bool isDeSpawn = false;
    
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isDeSpawn = true;
        }
    }
}