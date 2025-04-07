using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAttack : ModelMonoBehaviour
{
    private float fireRate = 2.0f;
    [SerializeField] private bool canShoot = true;

    [SerializeField]
    EnemyAnimationController enemyAnimationController;

    protected override void Awake()
    {
        enemyAnimationController = transform
            .parent.Find("Model")
            .GetComponent<EnemyAnimationController>();
    }

    private void Update()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        try
        {
            if (enemyAnimationController != null &&
                enemyAnimationController.IsAttackAnimationFinished && canShoot)
            {
                Debug.Log("Can shoot");
                canShoot = false;

                string bulletType = this.getBulletType();

                Transform newBullet = BulletEnemySpawner.Instance.Spawn(
                    bulletType,
                    transform.parent.position,
                    transform.parent.rotation
                );

                if (newBullet == null)
                {
                    return;
                }

                newBullet.gameObject.SetActive(true);

                try
                {
                    SoundFXManager.Instance.PlaySound("EnemyAttack");
                }
                catch (Exception soundEx)
                {
                    Debug.LogWarning("Không thể phát âm thanh EnemyAttack: " + soundEx.Message);
                }

                Debug.Log("Shooting");

                StartCoroutine(this.ResetCanShootCoroutine(fireRate));
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Lỗi trong quá trình bắn đạn Enemy: " + e.Message);
        }
    }

    private IEnumerator ResetCanShootCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
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
