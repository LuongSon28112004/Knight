using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ModelMonoBehaviour
{
   //properties of class 
   [SerializeField] protected Vector3 targetPosition;
   [SerializeField] protected float movespeed = 5;
   [SerializeField] protected Vector3 direction = Vector3.right;

   //khởi động lần đầu tiền khi game chạy 
   protected override void Awake(){
      base.Awake();
      targetPosition = GameObject.Find("Player").transform.position;
      this.LookAtTarget();//đảm bảo chỉ kiểm tra hướng lần đầu tiền khi khởi tạo
   }

   //khi gameobject được bật lại
   protected void OnEnable(){
      targetPosition = GameObject.Find("Player").transform.position;
      this.LookAtTarget(); // đảm bảo chỉ kiểm tra hướng khi bật lại
   }

   //function update other frame 
   void Update()
   {
      this.move();
   }

   //hàm giúp di chuyển bullet 
   private void move()
   {
      transform.parent.Translate(this.direction * movespeed * Time.deltaTime);
   }

   //hàm giúp tính toán hướng của bullet và player để giúp bullet có thể bay đến đúng hướng mà player đang đứng
   protected virtual void LookAtTarget(){
        Vector3 diff = this.targetPosition - this.transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0 , 0 , rot_z);
    }
}
