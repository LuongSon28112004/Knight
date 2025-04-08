using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> listItem = new List<GameObject>();
    private static RandomItem instance;
    public static RandomItem Instance
    {
        get => instance;
    }

    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("can't have 2 input maanger in obj");
        instance = this;
    }

    public void SpawnItem(Vector3 position, Quaternion rotation)
    {
        int ramdomCoin = Random.Range(StaticConst.MIN_COIN, StaticConst.MAX_COIN);
        int randomHeartJar = Random.Range(StaticConst.MIN_HEALTH, StaticConst.MAX_HEALTH);
        for (int i = 0; i < ramdomCoin; i++)
        {
            GameObject coin = Instantiate(listItem[0], position, rotation);
            coin.gameObject.SetActive(true);
            coin.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7.0f, ForceMode2D.Impulse);
            coin.transform.parent = this.transform;
        }
        for (int i = 0; i < randomHeartJar; i++)
        {
            GameObject heartJar = Instantiate(listItem[1], position, rotation);
            heartJar.transform.SetParent(this.transform);
            heartJar.gameObject.SetActive(true);
            heartJar.transform.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7.0f, ForceMode2D.Impulse);
            heartJar.transform.parent = this.transform;
        }
    }
}
