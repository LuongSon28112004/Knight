using System.Collections;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    // Lực đẩy của enemy
    public float knockbackForce = 0.1f;
    // Thời gian giữ hiệu ứng đẩy (nếu cần)
    public float knockbackDuration = 0.1f;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        // Đảm bảo enemy có Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Phương thức được gọi khi enemy bị chém
    public void ApplyKnockback(Transform playerTransform)
    {
        if(rb == null) return;
        float direction = Mathf.Sign(playerTransform.localScale.x);
        Vector2 knockbackDirection = new Vector2(direction, 0); // Đẩy ngang

        // Áp dụng lực đẩy
        rb.linearVelocity = Vector2.zero; // Reset vận tốc trước khi đẩy
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        // Reset lại vận tốc sau thời gian knockbackDuration
        StartCoroutine(ResetVelocityAfterTime(knockbackDuration));
    }

    IEnumerator ResetVelocityAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        rb.linearVelocity = Vector2.zero; // Dừng enemy sau knockback
    }
}
