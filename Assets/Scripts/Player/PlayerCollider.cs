using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : ModelMonoBehaviour
{
    protected static PlayerCollider instance;
    public static PlayerCollider Instance { get => instance; }

    [SerializeField] private bool isGround;
    public bool IsGround { get => isGround; set => isGround = value; } 

    protected override void Awake()
    {
        if(instance != null) Debug.LogWarning("can't not 2 PlayerCollider on obj");
        PlayerCollider.instance = this;
        isGround = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground")){
            isGround = true;
            Debug.Log("Play is on the ground");
        }
    }

}
