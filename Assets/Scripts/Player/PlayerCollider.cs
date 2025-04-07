using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : ModelMonoBehaviour
{
    protected static PlayerCollider instance;
    public static PlayerCollider Instance { get => instance; }

    [SerializeField] private bool isGround;
    public bool IsGround { get => isGround; set => isGround = value; }

    [SerializeField] private PlayerDamagerReceiver playerDamagerReceiver;
    protected override void Awake()
    {
        if (instance != null) Debug.LogWarning("can't not 2 PlayerCollider on obj");
        PlayerCollider.instance = this;
        isGround = true;
    }

    void Start()
    {
        playerDamagerReceiver = transform.parent.Find("PlayerCollider").GetComponent<PlayerDamagerReceiver>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            isGround = true;
            Debug.Log("Play is on the ground");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Apple") && other.gameObject.CompareTag("Apple"))
        {
            PlayerInventory.Instance.AddPlayerItem(new PlayerItem("Apple", "none"), 1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.name.Contains("Heart") && other.gameObject.CompareTag("Heart"))
        {
            playerDamagerReceiver.CurrentHP += 1;
            if(playerDamagerReceiver.CurrentHP >= playerDamagerReceiver.MaxHP)
            {
                playerDamagerReceiver.CurrentHP = playerDamagerReceiver.MaxHP;
            }
            Destroy(other.gameObject);
        }
    }

}
