using System.Collections;
using UnityEngine;

public class PlayerAttack : ModelMonoBehaviour
{
    [SerializeField]
    private float fireRate = 1f;
    private bool canShoot = true;

    private void Update()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if(
            InputManager.Instance.OnKeyC
            && canShoot
            && PlayerInventory.Instance.PlayerItems.Count > 0
            && PlayerInventory.Instance.PlayerItems[new PlayerItem("Apple", "none")] != null
            && PlayerInventory.Instance.PlayerItems[new PlayerItem("Apple", "none")] > 0
        )
        {
            StartCoroutine(ShootWithDelay());
            PlayerInventory.Instance.RemovePlayerItem(new PlayerItem("Apple", "none"), 1);//tru bot tao khi ban ra
        }
    }

    private IEnumerator ShootWithDelay()
    {
        canShoot = false;
        Transform bulletApple = BulletPlayerSpawner.Instance.Spawn(
            BulletPlayerSpawner.apple,
            transform.parent.position + new Vector3(0, 0.5f, 0),
            transform.parent.rotation
        );
        if (bulletApple == null)
        {
            yield break;
        }

        bulletApple.gameObject.SetActive(true);
        Debug.Log("player Shooting");

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
