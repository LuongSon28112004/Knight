using UnityEngine;

public class HeartJarCollider : MonoBehaviour
{
    [SerializeField] PlayerDamagerReceiver playerDamagerReceiver;
    private void Start()
    {
        playerDamagerReceiver = GameObject.Find("Player").GetComponentInChildren<PlayerDamagerReceiver>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDamagerReceiver.Add(2); // Thêm 1 trái tim khi va chạm với Player
            SoundFXManager.Instance.PlaySound("PlayerEatItem"); // Phát âm thanh khi nhặt HeartJar
            Destroy(gameObject); // Hủy đối tượng coin sau khi va chạm
        }
    }
}
