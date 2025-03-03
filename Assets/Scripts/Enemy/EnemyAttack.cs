using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAttack : ModelMonoBehaviour
{

    [SerializeField] private int bulletsNumber = 1;
    [SerializeField] EnemyAnimationController enemyAnimationController;

    protected override void Awake()
    {
        enemyAnimationController = transform.parent.Find("Model").GetComponent<EnemyAnimationController>();
    }

   private void Update() {
      this.Shooting();
   }
   protected virtual void Shooting(){
        if (enemyAnimationController.IsAttackAnimationFinished && bulletsNumber == 1)
        {
            string bulletType = this.getBulletType();
            Transform newBullet = BulletEnemySpawner.Instance.Spawn(bulletType, transform.parent.position, transform.parent.rotation);
            if (newBullet == null) {
                return;
            }
            newBullet.gameObject.SetActive(true);
            bulletsNumber = 0;
            Debug.Log("Shooting");
        }

        if (!enemyAnimationController.IsAttackAnimationFinished)
        {
            bulletsNumber = 1;
        }
   }

   private string getBulletType()
   {
       string parentName = transform.parent.name;

        if (parentName.Contains("Wizzart_C"))
        {
            return BulletEnemySpawner.bullet_One;
        }
        else if (parentName.Contains("Wizzart_A"))
        {
            return BulletEnemySpawner.bullet_Two;
        }

        return null;
   }
}
