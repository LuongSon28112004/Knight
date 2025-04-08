using UnityEngine;

public class CloundMove : MonoBehaviour
{
    [SerializeField] private GameObject clouds;
    private float MaxX = 20.0f;
    private float MinX = -10.0f;
    void Start()
    {
        clouds = GameObject.FindGameObjectWithTag("Clouds");
        if (clouds == null)
        {
            Debug.LogError("Clouds GameObject not found in the scene.");
            return;
        }
    }

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
