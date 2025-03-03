using UnityEngine;

public class BulletPlayerFly : BulletFly
{
    protected override void Awake()
    {
        base.Awake();
    }

    //khi gameobject được bật lại
    protected void OnEnable()
    {
        // //targetPosition = GameObject.Find("Player").transform.position;
        // this.LookAtTarget(); // đảm bảo chỉ kiểm tra hướng khi bật lại
    }
}
