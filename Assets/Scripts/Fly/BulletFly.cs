using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ModelMonoBehaviour
{
   //properties of class 
   [SerializeField] protected float movespeed = 5;
   [SerializeField] protected Vector3 direction = Vector3.right;

   //khởi động lần đầu tiền khi game chạy 


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
}
