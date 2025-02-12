using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : ModelMonoBehaviour
{
    [SerializeField] private bool isCheck;

    public bool IsCheck { get => isCheck;}

    protected override void Awake()
    {
        base.Awake();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("check"))
        {
            isCheck = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("check"))
        {
            isCheck = false;
        }
    }
}


