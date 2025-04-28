using System;
using UnityEngine;

public class ChestCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            OpenChest(); // Call the method to open the chest and give items
            Destroy(gameObject); // Destroy the chest after opening
        }
    }

    private void OpenChest()
    {
        RandomItem.Instance.SpawnItem(transform.position, transform.rotation); // Call the method to open the chest and give items
    }
}
