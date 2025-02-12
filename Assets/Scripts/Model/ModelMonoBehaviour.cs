using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents(){
        //For ovveride
    }
}
