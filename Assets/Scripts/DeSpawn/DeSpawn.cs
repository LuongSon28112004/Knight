using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : ModelMonoBehaviour
{
    protected virtual void FixedUpdate()
   {
        this.DeSpawning();
   }

    protected void DeSpawning()
    {
        if(!this.CanDespawn()) return;
        this.DeSpawnObject();
    }

    protected virtual void DeSpawnObject(){
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();
}
