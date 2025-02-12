using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemySpawner : Spawner
{
    protected static BulletEnemySpawner instance;
    public static BulletEnemySpawner Instance { get => instance;}

    [SerializeField] public static string bullet_One = "Bullet";
    [SerializeField] public static string bullet_Two = "Bullet_Wizzart_A";
    protected override void Awake()
    {
        if(BulletEnemySpawner.instance != null) Debug.LogWarning("can't have 2 input maanger in obj");
        BulletEnemySpawner.instance = this;
    }
}
