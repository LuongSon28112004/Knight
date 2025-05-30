using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ModelMonoBehaviour
{
    //properties of class
    [SerializeField]
    protected float movespeed = 5;

    [SerializeField]
    protected Vector3 direction = Vector3.right;

    protected virtual void Update()
    {
        this.move();
    }

    protected virtual void Start()
    {
        //for start
    }

    //hàm giúp di chuyển bullet
    protected virtual void move()
    {
        transform.parent.Translate(this.direction * movespeed * Time.deltaTime);
    }
}
