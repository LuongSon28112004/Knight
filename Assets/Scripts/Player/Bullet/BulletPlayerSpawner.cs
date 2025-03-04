using UnityEngine;

public class BulletPlayerSpawner : Spawner
{
    protected static BulletPlayerSpawner instance;
    public static BulletPlayerSpawner Instance { get => instance; }

    [SerializeField] public static string apple = "Apple";

    protected override void Awake()
    {
        if (BulletPlayerSpawner.Instance != null) Debug.LogWarning("can't have 2 input maanger in obj");
        BulletPlayerSpawner.instance = this;
    }
}
