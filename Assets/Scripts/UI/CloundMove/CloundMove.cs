using UnityEngine;

public class CloundMove : MonoBehaviour
{
    private float MaxX = 20.0f;
    private float MinX = -10.0f;

    // Update is called once per frame
    void Update()
    {
        this.move();
    }

    private void move()
    {
        if(transform.position.x > MaxX)
        {
            transform.position = new Vector3(MinX, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3(transform.position.x + 0.005f, transform.position.y, transform.position.z);
    }
}
