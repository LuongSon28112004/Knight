using UnityEngine;

public class BulletEnemyFly : BulletFly
{
    [SerializeField] protected Vector3 targetPosition;
    protected override void Awake()
    {
        base.Awake();
        targetPosition = GameObject.Find("Player").transform.position;
        this.LookAtTarget();//đảm bảo chỉ kiểm tra hướng lần đầu tiền khi khởi tạo
    }

    //khi gameobject được bật lại
    protected void OnEnable()
    {
        targetPosition = GameObject.Find("Player").transform.position;
        this.LookAtTarget(); // đảm bảo chỉ kiểm tra hướng khi bật lại
    }
   
   //hàm giúp tính toán hướng của bullet và player để giúp bullet có thể bay đến đúng hướng mà player đang đứng
   protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - this.transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z);
    }
}
