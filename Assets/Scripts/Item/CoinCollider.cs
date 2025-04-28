using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinManager.Instance.AddCoin(1); // Thêm 1 coin khi va chạm với Player
            Destroy(gameObject); // Hủy đối tượng coin sau khi va chạm
        }
    }
}
