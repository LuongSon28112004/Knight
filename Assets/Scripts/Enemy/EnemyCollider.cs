using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : ModelMonoBehaviour
{
    public float rayLength1 = 1f; // Độ dài tia ray
    public float rayLength2 = 2f; // độ dài tia ray 2
    public LayerMask playerLayer; // Layer của Enemy
    [SerializeField]
    private bool isCheckCollMap; // cham tuong
    public bool IscheckCollMap{
        get => isCheckCollMap;
    }

    [SerializeField]
    private bool isFallabyss;//roi xuong vuc
    public bool IsFallabyss
    {
        get => isFallabyss;
    }


    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        //Debug.Log("raycast");
        this.checkChangeDirection();
    }

    public void checkChangeDirection()
    {
        Vector2 origin; // Lấy vị trí của chính nó
        Vector2 direction1;
        Vector2 direction2;
        if (transform.parent.Find("Model").GetComponent<SpriteRenderer>().flipX == true)
        {
            origin = transform.position - new Vector3(0.8f,0);
            direction1 = Vector2.down;
            direction2 = Vector2.down;
        }
        else
        {
            origin = transform.position + new Vector3(0.8f,0);
            direction1 = Vector2.down; // Hướng tia ray sang phải
            direction2 = Vector2.down;
        }

        // Bắn tia ray từ Enemy
        RaycastHit2D hit = Physics2D.Raycast(origin, direction1, rayLength1, playerLayer);
        RaycastHit2D hit_1 = Physics2D.Raycast(origin, direction2, rayLength2, playerLayer);

        // Vẽ tia ray từ đúng vị trí
        Debug.DrawRay(origin, direction1 * rayLength1, Color.red);
        Debug.DrawRay(origin, direction2 * rayLength2, Color.green);

        // Nếu raycast chạm vào một đối tượng trong Layer "Player"
        if (hit.collider != null)
        {
            this.isCheckCollMap = true;
            Debug.Log("Đã phát hiện Player: raycast1 " + hit.collider.name);
        }
        else this.isCheckCollMap = false;

        if(hit_1.collider != null)
        {
            this.isFallabyss = false;
            Debug.Log("Đã phát hiện Player: raycast2 " + hit_1.collider.name);
        }   
        else this.isFallabyss = true;
    }
}
