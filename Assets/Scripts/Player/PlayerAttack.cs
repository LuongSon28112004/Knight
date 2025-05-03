using System;
using System.Collections;
using UnityEngine;

public class PlayerAttack : ModelMonoBehaviour
{
    [SerializeField]
    private float fireRate = 2f;
    private bool canShoot = true;

    [SerializeField] private ShootingButton shootingButton;

    void Start()
    {
        shootingButton.OnShooting += ButtonShooting;
    }

    private void Update()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        try
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
        }catch(Exception ex)
        {
             Debug.LogWarning($"Error in Shooting: {ex.Message}");
        }
    }
    
    protected virtual void ButtonShooting()
    {
        try
        {
                if(canShoot
                && PlayerInventory.Instance.PlayerItems.Count > 0
                && PlayerInventory.Instance.PlayerItems[new PlayerItem("Apple", "none")] != null
                && PlayerInventory.Instance.PlayerItems[new PlayerItem("Apple", "none")] > 0
            )
            {
                StartCoroutine(ShootWithDelay());
                PlayerInventory.Instance.RemovePlayerItem(new PlayerItem("Apple", "none"), 1);//tru bot tao khi ban ra
            }
        }catch(Exception ex)
        {
             Debug.LogWarning($"Error in Shooting: {ex.Message}");
        }
    }

    private IEnumerator ShootWithDelay()
    {
        try
        {
            canShoot = false;
            Transform bulletApple = BulletPlayerSpawner.Instance.Spawn(
                BulletPlayerSpawner.apple,
                transform.parent.position + new Vector3(0, 0.3f, 0),
                transform.parent.rotation
            );
            if (bulletApple == null)
            {
                yield break;
            }

            bulletApple.gameObject.SetActive(true);
            try
            {
                SoundFXManager.Instance.PlaySound("PlayerAttack");
            }
            catch (Exception soundEx)
            {
                Debug.LogWarning("Không thể phát âm thanh PlayerAttack: " + soundEx.Message);
            }
            Debug.Log("player Shooting");
        }
        catch (Exception ex)
        {
            Debug.LogError($"[PlayerAttack] Error in ShootWithDelay: {ex.Message}");
        }
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
