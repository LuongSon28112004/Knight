using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 40.0f;
    [SerializeField] protected float distance = 0.0f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera(){
        if(this.mainCam != null) return;
            this.mainCam = Transform.FindObjectOfType<Camera>().transform;
            Debug.Log(transform.parent.name + ": Load Camera " + gameObject);
        }

    protected override bool CanDespawn(){
        this.distance = Vector3.Distance(transform.position, this.mainCam.transform.position);
        if(distance > disLimit)return true;
            return false;
    }
}
