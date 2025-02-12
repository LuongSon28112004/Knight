using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : ModelMonoBehaviour
{
      // Player cần theo dõi
    [SerializeField] Transform player;

    // Khoảng cách giữa Camera và Player
    [SerializeField] Vector3 offset;

    // Độ mượt mà khi di chuyển
    [SerializeField] float smoothSpeed = 0.125f;

    protected override void Awake()
    {
        base.Awake();
        offset = transform.position;
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // Vị trí mong muốn của Camera
        Vector3 desiredPosition = player.position + offset;

        // Di chuyển Camera một cách mượt mà từ vị trí hiện tại đến vị trí mong muốn
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Gán vị trí mới cho Camera
        transform.position = smoothedPosition;
    }
}
